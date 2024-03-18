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

namespace itApp.Application.Features.Commands.Employe.DeleteEmploye
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommandRequest, DeleteEmployeeCommandResponse>
    {

        readonly IEmployeWriteRepository _writeRepository;


        public DeleteEmployeeCommandHandler(IEmployeWriteRepository writeRepository)
        {
            _writeRepository = writeRepository;
        }
        public async  Task<DeleteEmployeeCommandResponse> Handle(DeleteEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if(Guid.TryParse(request.Id,out Guid result))
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
