using AutoMapper;
using itApp.Application.Abstractions.Services;
using itApp.Application.Exceptions;
using itApp.Application.Features.Commands.Employe.CreateEmploye;
using itApp.Application.Repositories;
using itApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itApp.Application.Features.Commands.Employe.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommandRequest, UpdateEmployeeCommandResponse>
    {
        readonly IEmployeWriteRepository _writeRepository;
        readonly IEmployeReadRepository _readRepository;
        readonly IDepartmentReadRepository _departmentReadRepository;
        readonly IUserService _userService;
        private IMapper _mapper;

        public UpdateEmployeeCommandHandler(IMapper mapper, IUserService userService, IDepartmentReadRepository departmentReadRepository, IEmployeReadRepository readRepository, IEmployeWriteRepository writeRepository)
        {
            _mapper = mapper;
            _userService = userService;
            _departmentReadRepository = departmentReadRepository;
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<UpdateEmployeeCommandResponse> Handle(UpdateEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            try
                {
                    itApp.Domain.Entities.Employe oldEmp = await _readRepository.GetByIdAsync(request.Id);
                    if (!(oldEmp.EmployeTelNo == request.EmployeTelNo)) // telefon numarası degiştiyse 
                    {
                        bool employeTelNoExists = await _readRepository.IsEmployeExists(request.EmployeTelNo);// tel no varsa bir daha eklemiyor.
                        if (employeTelNoExists)
                            throw new Exception("Aynı telefon numarasına kayıtlı bir çalışan zaten mevcut.");

                        oldEmp.EmployeTelNo = request.EmployeTelNo; // degiştiriyirouz hata yoksa
                    }

                    if (!(oldEmp.DepartmentId.ToString() == request.DepartmentId)) // telefon numarası degiştiyse 
                    {
                        bool departmanExists = await _departmentReadRepository.IsExists(request.DepartmentId);
                        if (!departmanExists)
                            throw new Exception("Departman bulunamadı, Lütfen geçerli bir departman seçiniz.");
                        if (Guid.TryParse(request.DepartmentId, out Guid result))
                        {
                            oldEmp.DepartmentId = result;
                        }
                        else
                            throw new IdParseErrorException("Departman Id type must be guid");

                    }
                    if (!(oldEmp.EmployeName == request.EmployeName))
                        oldEmp.EmployeName = request.EmployeName;
                    if (!(oldEmp.EmployeSurname == request.EmployeSurname))
                        oldEmp.EmployeSurname = request.EmployeSurname;

                    await _writeRepository.SaveAsync();

                }
                catch (Exception ex)
                {
                    // loglama yapılıp tekrar fırlatılabilir
                    throw;
                }

            return new() { Message = request.EmployeName + " başarılı bir şekilde update edildi .", Succeeded = true };
          
         
           
        }
        public Guid StringToGuidConverter(string id)
        {
            if (Guid.TryParse(id, out Guid parsedId))
                return parsedId;
            else
                throw new IdParseErrorException();
        }
    }
}
