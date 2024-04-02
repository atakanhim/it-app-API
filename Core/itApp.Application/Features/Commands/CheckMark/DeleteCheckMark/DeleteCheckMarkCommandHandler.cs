using itApp.Application.Exceptions;
using itApp.Application.Features.Commands.Employe.DeleteEmploye;
using itApp.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itApp.Application.Features.Commands.CheckMark.DeleteCheckMark
{
    public class DeleteCheckMarkCommandHandler : IRequestHandler<DeleteCheckMarkCommandRequest, DeleteCheckMarkCommandResponse>
    {
        readonly ICheckMarkWriteRepository _writeRepository;

        public DeleteCheckMarkCommandHandler(ICheckMarkWriteRepository writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<DeleteCheckMarkCommandResponse> Handle(DeleteCheckMarkCommandRequest request, CancellationToken cancellationToken)
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

            return new() { Message = "puantaj silme işlemi basarili " };
        }
    }
}
