using congestion.calculator;
using Dto.UseCases.Responses;

using System;
using Interfaces;

namespace Dto.UseCases.Requests;

public class GetTaxRequestDtoUseCase 
{
    public Vehicle Vehicle { get; }
    public DateTime[] Dates { get; }

    public GetTaxRequestDtoUseCase() { }
    public GetTaxRequestDtoUseCase(Vehicle vehicle, DateTime[] dates)
    {
        Vehicle = vehicle;
        Dates = dates;
    }
}

