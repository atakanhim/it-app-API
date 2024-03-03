using AutoMapper;
using itApp.Application.Features.Commands.Employe.CreateEmploye;
using itApp.Application.Repositories;
using entiti = itApp.Domain.Entities;
using MediatR;


namespace itApp.Application.Features.Commands.CheckMark.CreateCheckMark
{
    public class CreateCheckMarkCommandHandler : IRequestHandler<CreateCheckMarkCommandRequest, CreateCheckMarkCommandResponse>
    {
        private readonly IEmployeReadRepository _employeReadRepository;
        private readonly ICheckMarkWriteRepository _checkMarkWriteRepository;
        private readonly ICheckMarkReadRepository _checkMarkReadRepository;
        private readonly IMapper _mapper;

        public CreateCheckMarkCommandHandler(IEmployeReadRepository employeReadRepository,ICheckMarkWriteRepository checkMarkWriteRepository,IMapper mapper,ICheckMarkReadRepository checkMarkReadRepository)
        {
            _employeReadRepository = employeReadRepository;
            _checkMarkWriteRepository = checkMarkWriteRepository;
            _mapper = mapper;
            _checkMarkReadRepository = checkMarkReadRepository;
        }

  
        public async Task<CreateCheckMarkCommandResponse> Handle(CreateCheckMarkCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                bool employeExists = await _employeReadRepository.IsExists(request.EmployeeId);
                if (!employeExists)
                    throw new Exception("Employe Bulunamadi.");

                if (Guid.TryParse(request.EmployeeId, out Guid parsedId))
                   {
                    entiti.CheckMark control = await _checkMarkReadRepository.GetSingleAsync(x => x.EmployeeId == parsedId && x.Date == request.StartDate);
                    if (control == null)// nullsa yok demektir eklicez
                    {
                        entiti.CheckMark checkMark = _mapper.Map<CreateCheckMarkCommandRequest, entiti.CheckMark>(request);

                        if (request.EndDate != null)
                        {
                            List<entiti.CheckMark> checkMarks = new List<entiti.CheckMark>();
                            DateTime startTime = request.StartDate;
                            DateTime? endTime = request.EndDate;

                            // start date 01/04/2024
                            //end date  30/04/2024 
                            for (DateTime date = startTime; date <= endTime; date = date.AddDays(1))
                            {
                                entiti.CheckMark model = new entiti.CheckMark {
                                    EmployeeId = checkMark.EmployeeId,
                                    Date = date,
                                };
                               checkMarks.Add(model);
                            }
                               await _checkMarkWriteRepository.AddRangeAsync(checkMarks);
                        }
                        else
                            await _checkMarkWriteRepository.AddAsync(checkMark);
                       
                        await _checkMarkWriteRepository.SaveAsync();
                    }
                    else
                        throw new Exception("Aynı gunden aynı calisana tanımlama yapılmıs.");          
                   }
                else
                    throw new Exception("employeid guid parse error.");      

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return new() { Message = "basarili ", Succeeded = true };
        }
    }
}
