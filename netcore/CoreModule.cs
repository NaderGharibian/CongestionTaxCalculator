using Autofac;
using congestion.calculator.Interfaces;
using Dto.UseCases.Responses;

namespace congestion.calculator;

public class CoreModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        //builder.RegisterType<GetTaxRequestUseCase>().As<IGetTaxRequestUseCase>().InstancePerLifetimeScope();
        builder.RegisterType<Configuration>().As<IConfiguration>().SingleInstance();
 
        builder.RegisterType<GetTaxResponseDtoUseCase>().SingleInstance();
    }
}
