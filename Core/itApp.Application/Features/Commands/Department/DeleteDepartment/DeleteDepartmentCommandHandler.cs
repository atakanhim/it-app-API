using itApp.Application.Exceptions;
using itApp.Application.Features.Queries.EmployeeQueries.GetEmployee;
using itApp.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itApp.Application.Features.Commands.Department.DeleteDepartment
{
    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommandRequest, DeleteDepartmentCommandResponse>
    {
        readonly IDepartmentWriteRepository _writeRepository;

        public DeleteDepartmentCommandHandler(IDepartmentWriteRepository writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<DeleteDepartmentCommandResponse> Handle(DeleteDepartmentCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (Guid.TryParse(request.Id, out Guid result))
                    await _writeRepository.RemoveAsync(result);
                else
                    throw new IdParseErrorException();
                await _writeRepository.SaveAsync();

            }
            catch (Exception ex)
            {
                // loglama yapılıp tekrar fırlatılabilir
                throw;
            }

            return new() { Message = "basarili " };
        }
    }
}
