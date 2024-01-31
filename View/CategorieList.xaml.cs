using AgendaProjet.Data;
using AgendaProjet.Model;
using System.Collections.ObjectModel;

namespace AgendaProjet.View;

public partial class CategorieList : ContentPage
{
    private readonly Database database;
    public string SelectedCategoryName { get; set; }

    public event EventHandler<CategorieDef> CategorySelected;


    public ObservableCollection<CategorieDef> Items { get; set; } = new();
    public CategorieList(Database database)
    {
        InitializeComponent();

        this.database = database;

        BindingContext = this;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        var items = await database.GetCatgItemsAsync();

        MainThread.BeginInvokeOnMainThread(() =>
        {
            Items.Clear();
            foreach (var item in items)
                Items.Add(item);
        });
    }

    //private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    //{
    //    if (e.CurrentSelection.FirstOrDefault() is not CategorieDef selectedCategory)
    //        return;

    //    SelectedCategoryName = selectedCategory.CategoryName;

    //    var noteEditPage = Shell.Current.Navigation.NavigationStack.LastOrDefault() as NoteEdit;
    //    if (noteEditPage != null)
    //    {
    //        noteEditPage.SelectedCategory = selectedCategory;
    //        await Shell.Current.Navigation.PopModalAsync();
    //    }
    //}

    private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not CategorieDef item)
            return;

        CategorySelected?.Invoke(this, item);

        await Shell.Current.Navigation.PopModalAsync();
    }



    //private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    //{
    //    if (e.CurrentSelection.FirstOrDefault() is not CategorieDef item)
    //        return;

    //    await Shell.Current.GoToAsync(nameof(CategorieEdit), true, new Dictionary<string, object>
    //    {
    //        ["Item"] = item
    //    });
    //}

    private async void OnItemAdd(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(CategorieEdit), true, new Dictionary<string, object>
        {
            ["Item"] = new CategorieDef()
        });
    }
}

