using congestion.calculator;
using Dto.Contents;
using Dto.Enums;

namespace Dto.UseCases.Responses;

public class GetTaxResponseDtoUseCase : ResponseContentResult
{
    public int Tax { get; }
    public GetTaxResponseDtoUseCase(StatusCode result, ResponseMessage message ) : base(result, message) { }
    public GetTaxResponseDtoUseCase(int tax, StatusCode result, ResponseMessage message ) : base(result, message)
    {
        Tax = tax;
    }
}