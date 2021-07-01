using CarShop.Services;
using CarShop.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CarShop.Services.Contacts;
using MyWebServer;
using MyWebServer.Controllers;
using MyWebServer.Results.Views;

namespace CarShop
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
                    .Add<ApplicationDbContext>()
                    .Add<IValidator, Validator>()
                    .Add<IUsersService, UserService>()
                    .Add<IPasswordHasher , PasswordHasher>())
                .WithConfiguration<ApplicationDbContext>(c => c.Database.Migrate())

                .Start();
    }
}