using AgendaProjet.Data;
using AgendaProjet.Model;
using System;
using System.Collections.ObjectModel;

namespace AgendaProjet.View;



[QueryProperty("TachItem", "TachItem")]
public partial class TachEventEdit : ContentPage
{
    private readonly Database database;

    public TachEventDef TachItem
    {
        get => BindingContext as TachEventDef;
        set => BindingContext = value;
    }
    public ObservableCollection<TachEventDef> TachItems { get; }

    public TachEventEdit(Database database)
    {
        InitializeComponent();

        this.database = database;
    }

    public TachEventEdit(Database database, ObservableCollection<TachEventDef> tachItems) : this(database)
    {
        TachItems = tachItems;
    }

    protected override void OnAppearing()
    {
        if (TachItem.IdTach == 0)
        {
            Title = "Ajouter un intitule";
        }

        base.OnAppearing();
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TachItem.Titre))
        {
            await DisplayAlert("Titre obligatoire", "Veuillez entrer le titre pour continuer", "OK");
            return;
        }

        await database.SaveEvItemAsync(TachItem);
        await Shell.Current.GoToAsync("..", true);
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..", true);
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (TachItem.IdTach == 0)
            return;

        var answer = await DisplayAlert("Alerte", "Êtes-vous sûr de vouloir supprimer cette tache ?", "Oui", "Non");

        if (answer)
        {
            await database.DeleteItemAsync(TachItem);
            await Shell.Current.GoToAsync("..", true);
        }
    }


}