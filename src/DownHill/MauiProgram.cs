using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DownHill
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            // Registro do CorredorRepository no sistema de injeção de dependência
            builder.Services.AddSingleton<CorredorRepository>();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        private static string GetDatabasePath()
        {
            // Implemente a lógica para obter o caminho do banco de dados aqui
            return "path_to_your_database";
        }
    }
}
