using Autofac;
using congestion.calculator.Interfaces;
using congestion.calculator.UseCases;

using Dto.UseCases.Responses;

using Interfaces;

namespace congestion.calculator;

public class CoreModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<GetTaxUseCase>().As<IGetTaxUseCase>().InstancePerLifetimeScope();
        builder.RegisterType<Configuration>().As<IConfiguration>().SingleInstance();
    }
}
