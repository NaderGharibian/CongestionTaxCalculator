using congestion.calculator;

using Dto.Enums;

namespace Dto.UseCases.Responses;

public class GetTaxResponseDtoUseCase 
{
    public int Tax { get; }
    public StatusCode StatusCode { get; private set; }
    public ResponseMessage Message { get; private set; }
    public GetTaxResponseDtoUseCase() { }

    public GetTaxResponseDtoUseCase(StatusCode result, ResponseMessage message ){
        StatusCode = result;
        Message = message;
    
    }
    public GetTaxResponseDtoUseCase(int tax, StatusCode result, ResponseMessage message ) 
    {
        Tax = tax;
        StatusCode = result;
        Message = message;
    }
}