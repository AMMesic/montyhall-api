using System;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MontyHall.Application.DoorCalculation;

namespace MontyHall.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddSingleton<ICalculateDoors>(new CalculateDoors());

            return services;
        }
    }
}

