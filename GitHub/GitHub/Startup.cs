using System.Threading.Tasks;
using GitHub.Data;
using GitHub.Services;
using GitHub.Services.Contacts;
using MyWebServer;
using MyWebServer.Controllers;
using MyWebServer.Results.Views;
using Microsoft.EntityFrameworkCore;

namespace GitHub
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
                    .Add<IValidator , Validator>()
                    .Add<IUsersService, UserService>()
                    .Add<IPasswordHasher, PasswordHasher>())
                .WithConfiguration<ApplicationDbContext>(c => c.Database.Migrate())

                .Start();
    }
}
