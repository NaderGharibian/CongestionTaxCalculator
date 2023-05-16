
using Dto.UseCases.Requests;
using Dto.UseCases.Responses;

namespace Interfaces
{
    public interface IGetTaxUseCase : IHandlerUseCase<GetTaxRequestDtoUseCase, GetTaxResponseDtoUseCase>
    {
    }
}
