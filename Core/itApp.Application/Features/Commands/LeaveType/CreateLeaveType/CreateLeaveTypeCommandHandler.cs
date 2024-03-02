using AutoMapper;
using itApp.Application.Abstractions.Services;
using itApp.Application.Features.Commands.Department.CreateDepartment;
using itApp.Application.Features.Commands.Employe.CreateEmploye;
using itApp.Application.Features.Commands.LeaveRequest.CreateLeaveRequest;
using itApp.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itApp.Application.Features.Commands.LeaveType.CreateLeaveType
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommandRequest, CreateLeaveTypeCommandResponse>
    {
        readonly ILeaveTypeWriteRepository _leaveTypeWriteRepository;
        readonly ILeaveTypeReadRepository _leaveTypeReadRepository;
        private IMapper _mapper;
        public CreateLeaveTypeCommandHandler(IMapper mapper,ILeaveTypeWriteRepository leaveTypeWriteRepository, ILeaveTypeReadRepository leaveTypeReadRepository)
        {
            _mapper = mapper;
            _leaveTypeWriteRepository = leaveTypeWriteRepository;
            _leaveTypeReadRepository = leaveTypeReadRepository;
        }
        public async Task<CreateLeaveTypeCommandResponse> Handle(CreateLeaveTypeCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {

                bool leaveTypeExists = await _leaveTypeReadRepository.IsLeaveTypeExists(request.Name);
                if (leaveTypeExists)
                    throw new Exception("İzin tipi zaten var başka bir izin tipi giriniz.");

                Domain.Entities.LeaveType entity = _mapper.Map<CreateLeaveTypeCommandRequest, Domain.Entities.LeaveType>(request);

                await _leaveTypeWriteRepository.AddAsync(entity);
                await _leaveTypeWriteRepository.SaveAsync();

            }
            catch (Exception ex)
            {
                // loglama yapılıp tekrar fırlatılabilir
                throw;
            }

            return new() { Message = "İzin tipi eklendi ", Succeeded = true };
        }
    }
}
