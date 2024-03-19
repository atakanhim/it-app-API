using AutoMapper;
using itApp.Application.Abstractions.Services;
using itApp.Application.DTOs;
using itApp.Application.DTOs.User;
using itApp.Application.Repositories;
using itApp.Domain.Entities;
using MediatR;

namespace itApp.Application.Features.Commands.Employe.CreateEmploye
{
    public class CreateUserCommandHandler : IRequestHandler<CreateEmployeCommandRequest, CreateEmployeCommandResponse>
    {
        readonly IEmployeWriteRepository _writeRepository;
        readonly IEmployeReadRepository _readRepository;
        readonly IDepartmentReadRepository _departmentReadRepository;
        readonly IUserService _userService;
        private IMapper _mapper;
        public CreateUserCommandHandler(IUserService userService, IEmployeReadRepository readRepository, IEmployeWriteRepository writeRepository,IMapper mapper, IDepartmentReadRepository departmentReadRepository)
        {
            _userService = userService;
            _mapper = mapper;
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _departmentReadRepository = departmentReadRepository;
        }

        public async Task<CreateEmployeCommandResponse> Handle(CreateEmployeCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                bool employeTelNoExists = await _readRepository.IsEmployeExists(request.EmployeTelNo);// tel no varsa bir daha eklemiyor.
                if (employeTelNoExists)
                    throw new Exception("Aynı telefon numarasına kayıtlı bir çalışan zaten mevcut.");

                bool userExists = await _userService.IsUserExists(request.AppUserId);
                if (!userExists)
                    throw new Exception("User Id bulunamadı, Lütfen tekrar giriş yapınız.");

                bool departmanExists = await _departmentReadRepository.IsExists(request.DepartmentId);
                if (!departmanExists)
                    throw new Exception("Departman bulunamadı, Lütfen geçerli bir departman seçiniz.");


                Domain.Entities.Employe employe = _mapper.Map<CreateEmployeCommandRequest, Domain.Entities.Employe>(request);

                await _writeRepository.AddAsync(employe);          
                await _writeRepository.SaveAsync();

            }
            catch (Exception ex)
            {
                // loglama yapılıp tekrar fırlatılabilir
                throw;
            }

            return new() { Message = request.EmployeName + " başarılı bir şekilde eklendi.", Succeeded = true };
        }
    }
}
