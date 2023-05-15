using Dto.Contents;

namespace Interfaces;

public interface IRequestUseCase<out TResponseUseCase> where TResponseUseCase : ResponseContentResult
{

}