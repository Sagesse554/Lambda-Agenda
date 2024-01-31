using AgendaProjet.Data;
using AgendaProjet.Model;
using System.Collections.ObjectModel;

namespace AgendaProjet.View;

public partial class TachEventList : ContentPage
{
    private readonly Database database;

    public ObservableCollection<TachEventDef> TachItems { get; set; } = new();

    public TachEventList(Database database)
    {
        InitializeComponent();

        this.database = database;

        BindingContext = this;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        var items = await database.GetEvItemsAsync();

        MainThread.BeginInvokeOnMainThread(() =>
        {
            TachItems.Clear();
            foreach (var item in items)
                TachItems.Add(item);
        });
        items = items.OrderBy(item => item.EventDate).ToList();// affichage par tri de date
    }


    private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not TachEventDef item)
            return;

        await Shell.Current.GoToAsync(nameof(TachEventEdit), true, new Dictionary<string, object>
        {
            ["TachItem"] = item
        });
    }

    private async void OnTachItemAdd(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(TachEventEdit), true, new Dictionary<string, object>
        {
            ["TachItem"] = new TachEventDef()
        });
    }
}

