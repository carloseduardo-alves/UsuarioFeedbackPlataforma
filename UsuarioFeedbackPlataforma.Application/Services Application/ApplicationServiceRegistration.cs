using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UsuarioFeedbackPlataforma.Core.Services_Domain;
using UsuarioFeedbackPlataforma.Infrastructure.Services_Infrastructure;

namespace UsuarioFeedbackPlataforma.Application.Services_Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IFeedbackService, FeedbackService>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}
