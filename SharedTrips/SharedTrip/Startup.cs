using Microsoft.EntityFrameworkCore;
using SharedTrip.Data;
using SharedTrip.Services;
using SharedTrip.Services.Contacts;
using System.Threading.Tasks;
using MyWebServer;
using MyWebServer.Controllers;
using SharedTrip.Controllers;
using MyWebServer.Results.Views;

namespace SharedTrip
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
                    .Add<IUserService, UserService>()
                    .Add<IPasswordHasher, PasswordHasher>())
                .WithConfiguration<ApplicationDbContext>(c => c.Database.Migrate())
                .Start();
    }
}
