using Microsoft.Extensions.Logging;
using AgendaProjet.Data;
using AgendaProjet.View;

namespace AgendaProjet;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddTransient<CategorieEdit>();

        builder.Services.AddSingleton<CategorieList>();

        builder.Services.AddSingleton<NoteEdit>();

        builder.Services.AddSingleton<NoteListView>();

        builder.Services.AddSingleton<NoteView>();

        builder.Services.AddTransient<TachEventEdit>();

        builder.Services.AddSingleton<TachEventList>();

        builder.Services.AddSingleton<Database>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
