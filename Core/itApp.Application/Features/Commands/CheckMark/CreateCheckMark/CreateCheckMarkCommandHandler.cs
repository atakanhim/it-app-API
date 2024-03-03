using AutoMapper;
using itApp.Application.Features.Commands.Employe.CreateEmploye;
using itApp.Application.Repositories;
using MediatR;


namespace itApp.Application.Features.Commands.CheckMark.CreateCheckMark
{
    public class CreateCheckMarkCommandHandler : IRequestHandler<CreateCheckMarkCommandRequest, CreateCheckMarkCommandResponse>
    {
        private readonly IEmployeReadRepository _employeReadRepository;
        private readonly ICheckMarkWriteRepository _checkMarkWriteRepository;
        private readonly IMapper _mapper;

        public CreateCheckMarkCommandHandler(IEmployeReadRepository employeReadRepository,ICheckMarkWriteRepository checkMarkWriteRepository,IMapper mapper)
        {
            _employeReadRepository = employeReadRepository;
            _checkMarkWriteRepository = checkMarkWriteRepository;
            _mapper = mapper;
        }

  
        public async Task<CreateCheckMarkCommandResponse> Handle(CreateCheckMarkCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                bool employeExists = await _employeReadRepository.IsExists(request.EmployeeId);
                if (!employeExists)
                    throw new Exception("Employe Bulunamadi.");

                Domain.Entities.CheckMark checkMark = _mapper.Map<CreateCheckMarkCommandRequest, Domain.Entities.CheckMark>(request);


                await _checkMarkWriteRepository.AddAsync(checkMark);
            
             
                await _checkMarkWriteRepository.SaveAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return new() { Message = "basarili ", Succeeded = true };
        }
    }
}
