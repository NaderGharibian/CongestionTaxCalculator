using Core.Dto.Contents;
using Core.Dto.Enums;

namespace Core.Dto.UseCases.Responses;

public class GetTaxResponseDtoUseCase : ResponseContentResult
{
    public int Tax { get; }
    public GetTaxResponseDtoUseCase(StatusCode result, ResponseMessage message ) : base(result, message) { }
    public GetTaxResponseDtoUseCase(int tax, StatusCode result, ResponseMessage message ) : base(result, message)
    {
        Customer = customer;
    }
}