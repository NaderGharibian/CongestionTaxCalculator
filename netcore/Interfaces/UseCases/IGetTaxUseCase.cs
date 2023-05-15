using Dto.UseCases.Requests;
using Dto.UseCases.Responses;

namespace Interfaces
{
    public interface IGetTaxUseCase : IRequestHandlerUseCase<GetTaxRequestDtoUseCase, GetTaxResponseDtoUseCase>
    {
    }
}
