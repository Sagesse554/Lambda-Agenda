namespace AgendaProjet.View;
using Data;

public partial class MobileHome : ContentPage
{
	private bool _isPanelTranslated;

    private readonly Database database;

    public MobileHome()
	{
		InitializeComponent();
		panelLeft.TranslateTo(-220, 0, 150);
        //cal.SelectedDate = DateTime.Now.AddDays(5);
        cal.SelectedDate = DateTime.Now;

    }
    private void TapGestureRecognizer_Tapped1(object sender, TappedEventArgs e)
	{
        if(_isPanelTranslated)
        {
            panelLeft.TranslateTo(-220, 0, 150);
        }
        else
        {
            panelLeft.TranslateTo(0, 0, 150);
        }
        _isPanelTranslated = !_isPanelTranslated;
	}

    private void TapGestureRecognizer_Tapped2(object sender, TappedEventArgs e)
    {
        Application.Current.MainPage.Navigation.PushAsync(new CategorieList(new Database()));
    }

    private void TapGestureRecognizer_Tapped3(object sender, TappedEventArgs e)
    {
        if (_isPanelTranslated)
        {
            panelLeft.TranslateTo(-220, 0, 150);
        }
        else
        {
            panelLeft.TranslateTo(0, 0, 150);
        }
        _isPanelTranslated = !_isPanelTranslated;
    }

    private void TapGestureRecognizer_Tapped4(object sender, TappedEventArgs e)
    {
        if (_isPanelTranslated)
        {
            panelLeft.TranslateTo(-220, 0, 150);
        }
        else
        {
            panelLeft.TranslateTo(0, 0, 150);
        }
        _isPanelTranslated = !_isPanelTranslated;
    }

    private void TapGestureRecognizer_Tapped5(object sender, TappedEventArgs e)
    {
       
        
            Application.Current.MainPage.Navigation.PushAsync(new Profile());
       
    }

    private void TapGestureRecognizer_Tapped6(object sender, TappedEventArgs e)
    {
        if (_isPanelTranslated)
        {
            panelLeft.TranslateTo(-220, 0, 150);
        }
        else
        {
            panelLeft.TranslateTo(0, 0, 150);
        }
        _isPanelTranslated = !_isPanelTranslated;
    }

    private void TapGestureRecognizer_taches(object sender, TappedEventArgs e)
    {
        Application.Current.MainPage.Navigation.PushAsync(new TachEventList(new Database()));

    }

    private void TapGestureRecognizer_notebook(object sender, TappedEventArgs e)
    {
        Application.Current.MainPage.Navigation.PushAsync(new NoteListView(new Database()));

    }

    //private void cal_OnDateSelected(object sender,DateTime e)
    //{

    //}
}