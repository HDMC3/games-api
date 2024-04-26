using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;

namespace Aplication;

public static class AplicationRegistration
{
    public static void AddAplication(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}