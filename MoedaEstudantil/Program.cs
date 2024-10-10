using Microsoft.EntityFrameworkCore;
using MoedaEstudantil;
using MoedaEstudantil.Data;

namespace MoedaEstudantil
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Inst�ncia da classe Startup
            var startup = new Startup(builder.Configuration);

            // Chama o m�todo ConfigureServices do Startup
            startup.ConfigureServices(builder.Services);

            var app = builder.Build();

            // Chama o m�todo Configure do Startup
            startup.Configure(app, app.Environment);

            // Executa o app
            app.Run();
        }
    }
}
