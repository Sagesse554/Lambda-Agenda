using AgendaProjet.Data;
using AgendaProjet.Model;
using System.Collections.ObjectModel;

namespace AgendaProjet.View;

public partial class NoteView : ContentPage
{
    private readonly Database database;

    public ObservableCollection<NotesDef> NoteItems { get; set; } = new();

    public NoteView(Database database)
    {

        InitializeComponent();

        this.database = database;

        BindingContext = this;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        var items = await database.GetNotesItemsAsync();

        MainThread.BeginInvokeOnMainThread(() =>
        {
            NoteItems.Clear();
            foreach (var item in items)
                NoteItems.Add(item);
        });
    }
    private async void EditButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NoteEdit());     
    }
}