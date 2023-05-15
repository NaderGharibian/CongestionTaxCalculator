using Dto.Contents;

using System.Threading.Tasks;

namespace Interfaces;

public interface IRequestHandlerUseCase<in TRequestUseCase, out TResponseUseCase>
    where TRequestUseCase : IRequestUseCase<ResponseContentResult>
    where TResponseUseCase : ResponseContentResult
{
    Task<bool> Handle(TRequestUseCase request, IResponseUseCase<TResponseUseCase> response);
}