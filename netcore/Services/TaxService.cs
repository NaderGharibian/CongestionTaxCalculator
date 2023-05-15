using congestion.calculator.Interfaces;
using Dto.UseCases.Requests;

namespace congestion.calculator.Services
{
    public class TaxService:TaxAbstract
    {
        public TaxService(GetTaxRequestDtoUseCase request, IConfiguration configuration): base(request, configuration) { }

    }
}
