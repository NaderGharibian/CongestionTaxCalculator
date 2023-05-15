// See https://aka.ms/new-console-template for more information

using Autofac;
using Autofac.Extensions.DependencyInjection;
using congestion.calculator;
using congestion.calculator.Dto;
using congestion.calculator.Interfaces;
using Microsoft.Extensions.DependencyInjection;

var containerBuilder = new ContainerBuilder();
containerBuilder.RegisterModule(new CoreModule());
var container = containerBuilder.Build();

var serviceProvider = new AutofacServiceProvider(container);
var configuration = serviceProvider.GetRequiredService<IConfiguration>();

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
Console.WriteLine("Hello, World!");
