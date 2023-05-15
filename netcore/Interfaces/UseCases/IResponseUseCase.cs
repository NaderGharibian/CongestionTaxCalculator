using Dto.Contents;

namespace Interfaces;

public interface IResponseUseCase<in TResponseUseCase> where TResponseUseCase : ResponseContentResult
{
    void Handle(TResponseUseCase response);
}