namespace AgendaProjet.View;
using Model;
public partial class SignIn : ContentPage
{
    

    public SignIn()
	{
		InitializeComponent();
	}

    private void Button_sign(object sender, EventArgs e)
    {
        User user = new User();
        int _a = user.sign(txtEmail.Text,txtUsername.Text, txtPassword.Text, txtPasswordOk.Text);

        switch (_a)
        {
            case 1:
                {
                    DisplayAlert("Alert", "Email existe deja", "OK");
                   

                }
                break;
            case 2:
                {
                    DisplayAlert("Ops", "Password trop court", "OK");
                }
                break;
            case 3:
                {
                    DisplayAlert("Alert", "les mots de passe sont different", "OK");
                }
                break;
            case 4:
                {
                    
                    DisplayAlert("youpi", "connexion reussi", "OK");
                   // Application.Current.MainPage.Navigation.PushAsync(new DesktopHome());
                }
                break;
                
        }
        if (string.IsNullOrWhiteSpace(txtEmail.Text) && string.IsNullOrWhiteSpace(txtUsername.Text) && string.IsNullOrWhiteSpace(txtPassword.Text) && string.IsNullOrWhiteSpace(txtPasswordOk.Text))
        {
            DisplayAlert("...", "Il reste un/des champs libre(s)", "OK");

        }
    }

    private void TapGestureRecognizer_Tapped1(object sender, EventArgs e)
    {
        Application.Current.MainPage.Navigation.PushAsync(new Login());

    }
}