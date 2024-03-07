using AutoMapper;
using itApp.Application.Abstractions.Services;
using itApp.Application.Exceptions;
using itApp.Application.Features.Commands.Employe.CreateEmploye;
using itApp.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itApp.Application.Features.Commands.LeaveRequest.CreateLeaveRequest
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommandRequest, CreateLeaveRequestCommandResponse>
    {
        readonly IEmployeReadRepository _employeReadRepository;
        readonly IEmployeWriteRepository _employeWriteRepository;
        readonly ILeaveRequestReadRepository _leaveRequestReadRepository;
        readonly ILeaveRequestWriteRepository _leaveRequestWriteRepository;
        readonly ILeaveTypeReadRepository  _leaveTypeReadRepository;
        private IMapper _mapper;
        public CreateLeaveRequestCommandHandler( IEmployeReadRepository readRepository, IMapper mapper,
            ILeaveRequestReadRepository leaveRequestReadRepository,ILeaveRequestWriteRepository leaveRequestWriteRepository, ILeaveTypeReadRepository leaveTypeReadRepository,IEmployeWriteRepository employeWriteRepository)
        {
            _mapper = mapper;
            _employeReadRepository = readRepository;
            _leaveRequestReadRepository = leaveRequestReadRepository;
            _leaveRequestWriteRepository = leaveRequestWriteRepository;
            _leaveTypeReadRepository = leaveTypeReadRepository;
            _employeWriteRepository = employeWriteRepository;
        }
        public async Task<CreateLeaveRequestCommandResponse> Handle(CreateLeaveRequestCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                bool employeExists = await _employeReadRepository.IsExists(request.EmployeeId);
                bool leaveTypeExists = await _leaveTypeReadRepository.IsExists(request.LeaveTypeId);
                if (!employeExists)
                    throw new Exception("Employe Bulunamadi.");

                if (Guid.TryParse(request.EmployeeId, out Guid parsedId))            
                    await _leaveRequestReadRepository.LeaveRequestControl(request.Reason,request.StartDate, request.EndDate, parsedId);                                 
                else
                    throw new IdParseErrorException();

              
                if (!leaveTypeExists)
                    throw new Exception("İzin tipi bulunamadı lütfen geçerli bir izin tipi seçiniz.");

         
                Domain.Entities.LeaveRequest entity = _mapper.Map<CreateLeaveRequestCommandRequest, Domain.Entities.LeaveRequest>(request);

                DateTime sDate = entity.StartDate;
                DateTime eDate = entity.EndDate;
                TimeSpan difference = eDate - sDate;
                // Farkı gün olarak al
                int differenceInDays = difference.Days + 1 ;
       
                await _leaveRequestWriteRepository.AddAsync(entity);
                await _leaveRequestWriteRepository.SaveAsync();


                Domain.Entities.Employe employee = await _employeReadRepository.GetByIdAsync(request.EmployeeId);
                employee.UsedLeaveDays += differenceInDays;
                await _employeWriteRepository.SaveAsync();

            }
            catch (Exception ex)
            {
                // loglama yapılıp tekrar fırlatılabilir
                throw;
            }

            return new() { Message = "basarili ", Succeeded = true };
        }
    }
}
