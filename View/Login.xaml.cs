
namespace AgendaProjet;
using Model;
using View;

public partial class Login : ContentPage

{
   

   

    public Login()
    {
        InitializeComponent();
       
    }
    private void Button_clicked(object sender, EventArgs e)
    { 
        User user = new User();
        int _a = user.log(txtEmail.Text, txtPassword.Text);
        
        switch (_a)
        {
            case 1:
                {
                     DisplayAlert("Alert", "Connexion reussi!", "OK");
                    Application.Current.MainPage.Navigation.PushAsync(new MobileHome());
                }
                break;
            case 2:
                {
                     DisplayAlert("Ops", "MOT DE PASS INCORRECT", "OK"); 
                }
                break;
            case 3:
                {
                     DisplayAlert("Alert", "Email n'existe pas", "OK");
                }
                break;
             default: {
                    DisplayAlert("Alert", "booooooooooo", "OK"); break; }
        }
        if (string.IsNullOrWhiteSpace(txtEmail.Text)  && string.IsNullOrWhiteSpace(txtPassword.Text))
        {
            DisplayAlert("...", "Il reste un/des champs libre(s)", "OK");

        }
    }

    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
         Application.Current.MainPage.Navigation.PushAsync(new SignIn()); ;
    }
}