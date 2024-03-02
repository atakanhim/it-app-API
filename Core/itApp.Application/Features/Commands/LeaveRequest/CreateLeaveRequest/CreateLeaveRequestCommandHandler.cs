using AutoMapper;
using itApp.Application.Abstractions.Services;
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
        readonly IDepartmentReadRepository _departmentReadRepository;
        readonly ILeaveRequestReadRepository _leaveRequestReadRepository;
        readonly ILeaveRequestWriteRepository _leaveRequestWriteRepository;
        readonly ILeaveTypeReadRepository  _leaveTypeReadRepository;
        readonly IUserService _userService;
        private IMapper _mapper;
        public CreateLeaveRequestCommandHandler(IUserService userService, IEmployeReadRepository readRepository, IMapper mapper,
            IDepartmentReadRepository departmentReadRepository, ILeaveRequestReadRepository leaveRequestReadRepository,ILeaveRequestWriteRepository leaveRequestWriteRepository, ILeaveTypeReadRepository leaveTypeReadRepository)
        {
            _userService = userService;
            _mapper = mapper;
            _employeReadRepository = readRepository;
            _departmentReadRepository = departmentReadRepository;
            _leaveRequestReadRepository = leaveRequestReadRepository;
            _leaveRequestWriteRepository = leaveRequestWriteRepository;
            _leaveTypeReadRepository = leaveTypeReadRepository;
        }
        public async Task<CreateLeaveRequestCommandResponse> Handle(CreateLeaveRequestCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                bool leaveRequestExists = await _leaveRequestReadRepository.IsLeaveRequestExists(request.Reason);
                if (leaveRequestExists)
                    throw new Exception("Aynı izin sebebiyle bir izin olusturulmus.");

                bool employeExists = await _employeReadRepository.IsExists(request.EmployeeId);
                if (!employeExists)
                    throw new Exception("Employe Bulunamadi.");

                bool leaveTypeExists = await _leaveTypeReadRepository.IsExists(request.LeaveTypeId);
                if (!leaveTypeExists)
                    throw new Exception("İzin tipi bulunamadı lütfen geçerli bir izin tipi seçiniz.");




                Domain.Entities.LeaveRequest entity = _mapper.Map<CreateLeaveRequestCommandRequest, Domain.Entities.LeaveRequest>(request);

                await _leaveRequestWriteRepository.AddAsync(entity);
                await _leaveRequestWriteRepository.SaveAsync();

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
