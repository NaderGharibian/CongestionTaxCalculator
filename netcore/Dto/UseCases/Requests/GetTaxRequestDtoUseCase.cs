using congestion.calculator;

using Core.Interfaces;

using System;

namespace Core.Dto.UseCases.Requests;

public class GetTaxRequestDtoUseCase : IRequestUseCase<int>
{
    public Vehicle Vehicle { get; }
    public DateTime[] Dates { get; }

    public GetTaxRequestDtoUseCase(Vehicle vehicle, DateTime[] dates)
    {
        Vehicle = vehicle;
        Dates = dates;
    }
}

