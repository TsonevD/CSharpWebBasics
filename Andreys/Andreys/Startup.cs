using System.Threading.Tasks;
using Andreys.Data;
using Andreys.Services;
using Andreys.Services.Contacts;
using Microsoft.EntityFrameworkCore;
using MyWebServer;
using MyWebServer.Controllers;
using MyWebServer.Results.Views;

namespace Andreys
{
    public class Startup
    {
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                    .Add<IViewEngine, CompilationViewEngine>()
                    .Add<AndreysDbContext>()
                    .Add<IValidator, Validator>()
                    .Add<IUserService, UserService>()
                    .Add<IPasswordHasher, PasswordHasher>())
                .WithConfiguration<AndreysDbContext>(c => c.Database.Migrate())
                .Start();
    }
}
