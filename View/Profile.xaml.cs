using SkiaSharp;
using System.ComponentModel;
using static AgendaProjet.Model.User;
namespace AgendaProjet.View;

public partial class Profile : ContentPage
{

    private string selectedElement;
    public Profile()
	{
		InitializeComponent();
        this.ch_email.Text = Global.CurrentUser.Email;
        this.ch_username.Text = Global.CurrentUser.Username;
    }
     

    //private void TapGestureRecognizer_TappedPass(object sender, TappedEventArgs e)
    //{
    //    Application.Current.MainPage.Navigation.PushAsync(new Ch_pas());
    //}
    //private async void TapGestureRecognizer_TappedTof(object sender, TappedEventArgs e)
    //{
    //    var selectionPage = new SelectionPage();

    //    // Attente de la sélection de l'élément
    //     await Navigation.PushModalAsync(selectionPage);

    //    // Vérification si un élément a été sélectionné
    //    if (!string.IsNullOrEmpty(selectionPage.SelectedElement))
    //    {
    //        // Récupérer l'élément sélectionné de la page de sélection
    //        var selectedElement = selectionPage.SelectedElement;

    //        // Afficher l'élément sélectionné sur la page principale
    //        //SelectedElementLabel.Text = $"Élément sélectionné : {selectedElement}";
    //    }
    //}

    private void TapGestureRecognizer_TappedModifUsername(object sender, TappedEventArgs e)
    {
    }
    private void TapGestureRecognizer_TappedModifEmail(object sender, TappedEventArgs e)
    {
    }

    private void Button_deconnect(object sender, EventArgs e)
    { }
    }

