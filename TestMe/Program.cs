// See https://aka.ms/new-console-template for more information

using Autofac;
using Autofac.Extensions.DependencyInjection;

using congestion.calculator;
using congestion.calculator.Dto;
using congestion.calculator.Interfaces;

using Dto.UseCases.Responses;

using Interfaces;

using Microsoft.Extensions.DependencyInjection;

var containerBuilder = new ContainerBuilder();
containerBuilder.RegisterModule(new CoreModule());
var container = containerBuilder.Build();

var serviceProvider = new AutofacServiceProvider(container);
var configuration = serviceProvider.GetRequiredService<IConfiguration>();
var getTax = serviceProvider.GetRequiredService<IGetTaxUseCase>();
var getResponseTax = serviceProvider.GetServices<GetTaxResponseDtoUseCase>();

configuration.SetTollFee(new List<TollFeeContent>
{
    new TollFeeContent(start: new TimeOnly (6),end: new TimeOnly(6,29), fee:8),
    new TollFeeContent(start: new TimeOnly (6,30),end: new TimeOnly(6,59), fee:13),
     new TollFeeContent(start: new TimeOnly (7),end: new TimeOnly(7,59), fee:18),
      new TollFeeContent(start: new TimeOnly (8),end: new TimeOnly(8,29), fee:13),
       new TollFeeContent(start: new TimeOnly (8,30),end: new TimeOnly(14,59), fee:8),
        new TollFeeContent(start: new TimeOnly (15),end: new TimeOnly(15,29), fee:13),
         new TollFeeContent(start: new TimeOnly (15,30),end: new TimeOnly(16,59), fee:18),
          new TollFeeContent(start: new TimeOnly (17),end: new TimeOnly(17,59), fee:13),
           new TollFeeContent(start: new TimeOnly (18),end: new TimeOnly(18,29), fee:8),
            new TollFeeContent(start: new TimeOnly (18,30),end: new TimeOnly(5,59), fee:0)
});



configuration.SetCalendar(from: DateOnly.Parse("2013-01-01"),
                          to: DateOnly.Parse("2013-03-01"),
                          holiday: new DateOnly[] { DateOnly.Parse("2013-01-01")}
                         );


var resultCar = await getTax.Handle(new Dto.UseCases.Requests.GetTaxRequestDtoUseCase(new Car(), new DateTime[] {
    DateTime.Parse("2013-01-14 21:00:00"), // fee = 0
    DateTime.Parse("2013-01-01 06:05:00"), // fee = 8 - holiday
    DateTime.Parse("2013-01-20 17:05:00"), // fee = 13 - saturday
    DateTime.Parse("2013-02-07 15:27:00"), // fee = 13
    DateTime.Parse("2013-02-08 06:27:00"), // fee = 8
    DateTime.Parse("2013-02-08 06:20:27"), // fee = 8
    DateTime.Parse("2013-02-08 14:35:00"),  // fee = 8
    DateTime.Parse("2013-02-21 15:35:00")  // fee = 18

    }));

Console.WriteLine($"Car - Toll fee = ${resultCar.Tax}");




var resultMotorcycle = await getTax.Handle(new Dto.UseCases.Requests.GetTaxRequestDtoUseCase(new Motorcycle(), new DateTime[] {
    DateTime.Parse("2013-01-14 21:00:00"), // fee = 0
    DateTime.Parse("2013-01-01 06:05:00"), // fee = 8 - holiday
    DateTime.Parse("2013-01-20 17:05:00"), // fee = 13 - saturday
    DateTime.Parse("2013-02-07 15:27:00"), // fee = 13
    DateTime.Parse("2013-02-08 06:27:00"), // fee = 8
    DateTime.Parse("2013-02-08 06:20:27"), // fee = 8
    DateTime.Parse("2013-02-08 14:35:00"),  // fee = 8
    DateTime.Parse("2013-02-21 15:35:00")  // fee = 18

    }));

Console.WriteLine($"Motorcycle - Toll fee = ${resultMotorcycle.Tax}");

Console.ReadLine();
