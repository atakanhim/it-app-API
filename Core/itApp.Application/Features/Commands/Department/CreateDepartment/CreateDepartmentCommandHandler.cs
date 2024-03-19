using itApp.Application.Abstractions.Services;
using itApp.Application.Features.Commands.Employe.CreateEmploye;
using itApp.Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itApp.Application.Features.Commands.Department.CreateDepartment
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommandRequest, CreateDepartmentCommandResponse>
    {
        readonly IDepartmentWriteRepository _departmanWriteRepository;
        readonly IDepartmentReadRepository _departmentReadRepository;
        public CreateDepartmentCommandHandler( IDepartmentWriteRepository writeRepository, IDepartmentReadRepository departmentReadRepository)
        {
            _departmanWriteRepository = writeRepository;
            _departmentReadRepository = departmentReadRepository;
        }

        public async Task<CreateDepartmentCommandResponse> Handle(CreateDepartmentCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var boolen = await _departmentReadRepository.IsDepartmentNameExists(request.Name);
                if (boolen)
                    throw new Exception("Aynı isimde bir departman zaten mevcut");
                
                await _departmanWriteRepository.AddAsync(new()
                {
                    Name = request.Name,
                });
                await _departmanWriteRepository.SaveAsync();

            } catch (Exception ex)
            {
                throw ex;
            }

            return new() { Message = request.Name + " departmanı başaşarılı bir şekilde eklendi.", Succeeded=true};
        }
    }
}
