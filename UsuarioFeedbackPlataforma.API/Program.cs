
using FluentValidation;
using UsuarioFeedbackPlataforma.Application.Commands.CreateFeedback;
using UsuarioFeedbackPlataforma.Infrastructure.Services_Infrastructure;
using UsuarioFeedbackPlataforma.Application.Services_Application;

namespace UsuarioFeedbackPlataforma.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddApplicationServices();


            builder.Services.AddTransient<IValidator<CreateFeedbackCommand>, CreateFeedbackCommandValidator>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
