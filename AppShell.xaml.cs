using AgendaProjet.View;

namespace AgendaProjet;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(NoteEdit), typeof(NoteEdit));
        Routing.RegisterRoute(nameof(CategorieEdit), typeof(CategorieEdit));
        Routing.RegisterRoute(nameof(NoteView), typeof(NoteView));
        Routing.RegisterRoute(nameof(TachEventEdit), typeof(TachEventEdit));
        Routing.RegisterRoute(nameof(SignIn), typeof(SignIn));

    }
}
