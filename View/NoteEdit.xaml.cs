using AgendaProjet.Data;
using AgendaProjet.Model;
using System;
using System.Collections.Generic;

namespace AgendaProjet.View;

[QueryProperty("NoteItem", "NoteItem")]

public partial class NoteEdit : ContentPage
{
    private readonly Database database;
    public NotesDef NoteItem
    {
        get => BindingContext as NotesDef;
        set => BindingContext = value;
    }
    public NoteEdit(Database database)
    {
        InitializeComponent();
        this.database = database;
        BindingContext = this;
    }


    public NoteEdit()
    {
    }

    protected override void OnAppearing()
    {
        if (NoteItem.IdNotes == 0)
        {
            Title = "Ajouter une note";
        }

        base.OnAppearing();
    }


    private async void OnSaveClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NoteItem.Intitule))
        {
            await DisplayAlert("Intitule obligatoire", "Veuillez entrer l'intitule pour continuer", "OK");
            return;
        }

        await database.SaveNoteItemAsync(NoteItem);
        await Shell.Current.GoToAsync("..", true);
    }

    private async void OnNoteItemEdit(object sender, ItemTappedEventArgs e)
    {
        // Récupérer la note sélectionnée
        if (e.Item is not NotesDef noteItem)
            return;

        // Récupérer la liste des catégories
        var categories = await database.GetCatgItemsAsync();

        // Ouvrir NoteEdit avec la note et les catégories
        await Shell.Current.GoToAsync(nameof(NoteEdit), true, new Dictionary<string, object>
        {
            ["NoteItem"] = noteItem,
            ["Categories"] = categories
        });

    }

    //private async void OnCategoryPickerTapped(object sender, TappedEventArgs e)
    //{
    //    var categorieListPage = new CategorieList(new Database());
    //    await Navigation.PushModalAsync(categorieListPage);
    //}


    private async void OnCategoryPickerTapped(object sender, TappedEventArgs e)
    {
        // Récupérez l'instance sélectionnée du Picker
        var selectedCategory = (CategorieDef)CategoryPicker.SelectedItem;
        //CategorieList.BindingContext = this; 

        // Naviguez vers la page CategorieList en tant que page modale
        await Navigation.PushModalAsync(new CategorieList(new Database()));
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..", true);
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (NoteItem.IdNotes == 0)
            return;

        var answer = await DisplayAlert("Alerte", "Êtes-vous sûr de vouloir supprimer cette Note ?", "Oui", "Non");

        if (answer)
        {
            await database.DeleteItemAsync(NoteItem);
            await Shell.Current.GoToAsync("..", true);
        }
    }


}