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

    //    // Attente de la s�lection de l'�l�ment
    //     await Navigation.PushModalAsync(selectionPage);

    //    // V�rification si un �l�ment a �t� s�lectionn�
    //    if (!string.IsNullOrEmpty(selectionPage.SelectedElement))
    //    {
    //        // R�cup�rer l'�l�ment s�lectionn� de la page de s�lection
    //        var selectedElement = selectionPage.SelectedElement;

    //        // Afficher l'�l�ment s�lectionn� sur la page principale
    //        //SelectedElementLabel.Text = $"�l�ment s�lectionn� : {selectedElement}";
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

