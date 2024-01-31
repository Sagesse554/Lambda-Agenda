using AgendaProjet.Data;
using AgendaProjet.Model;

namespace AgendaProjet.View;

[QueryProperty("Item", "Item")]
public partial class CategorieEdit : ContentPage
{
    private readonly Database database;

    public CategorieDef Item
    {
        get => BindingContext as CategorieDef;
        set => BindingContext = value;
    }

    public CategorieEdit(Database database)
    {
        InitializeComponent();

        this.database = database;
    }

    protected override void OnAppearing()
    {
        if (Item.IdCatg == 0)
        {
            Title = "Ajouter une categorie!";
        }

        base.OnAppearing();
    }
    private  void DisplayColorPalette(object sender, EventArgs e)
    {
        Button clickedButton = (Button)sender;
        string colorName = GetColorName(clickedButton);

        ColorFrame.BackgroundColor = clickedButton.BackgroundColor;
        Item.CategoryColor = colorName;
    }

    private string GetColorName(Button button)
    {
        // Map the button and its corresponding color names here
        Dictionary<Button, string> colorMappings = new Dictionary<Button, string>
        {

            { btn1, "Green" }, { btn2, "YellowGreen" }, { btn3, "Gray" }, { btn4, "Yellow" },   { btn5, "Blue" },
            { btn6, "Pink" },   { btn7, "Brown" }, { btn8, "Turquoise" },  { btn9, "Salmon" },  { btn10, "orange" },
            { btn11, "Indigo" }, { btn12, "Chocolate" },  { btn13, "DarkCyan" },  { btn14, "red" }, { btn15, "CornflowerBlue" }
        };

        if (colorMappings.TryGetValue(button, out string value))
        {
            return value;
        }

        return string.Empty; // Or handle the case when the button is not found in the mappings
    }


    private async void OnSaveClicked(object sender, EventArgs e)
    {
        var items = await database.GetCatgItemsAsync();
        foreach (var test in items)
        {
            if (CategoryEntry.Text.ToUpper().Equals(test.CategoryName) || CategoryEntry.Text.ToLower().Equals(test.CategoryName))
            {
                await DisplayAlert("Erreur!", "Cette categorie existe deja ", "OK");
                return;
            }
        }

        if (string.IsNullOrWhiteSpace(Item.CategoryName))
        {
            await DisplayAlert("Nom de la categorie obligatoire", "Veuillez entrer le nom de la categorie pour continuer", "OK");
            return;
        }
        if (string.IsNullOrWhiteSpace(Item.CategoryColor))
        {
            await DisplayAlert("Couleur de la catégorie obligatoire","Veuillez sélectionner une couleur pour la catégorie", "OK");
            return;
        }

        await database.SaveItemAsync(Item);
        await Shell.Current.GoToAsync("..", true);
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..", true);
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (Item.IdCatg == 0)
            return;

        var answer = await DisplayAlert("Alerte", "Êtes-vous sûr de vouloir supprimer cette Categorie ?", "Oui", "Non");

        if (answer)
        {
            await database.DeleteItemAsync(Item);
            await Shell.Current.GoToAsync("..", true);
        }
    }

}