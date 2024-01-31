namespace AgendaProjet;
using View;
public partial class ConfigureProfil : ContentPage
{
	

	public ConfigureProfil()
	{
		InitializeComponent();
	}

    private async void btn_switch(System.Object sender, System.EventArgs e)
    {
        //var loginPage = new Login(new LoginViewModel());
        //await Navigation.PushModalAsync(loginPage);
        await Navigation.PushModalAsync(new Login());
    }

    async void btn_switch1(System.Object sender, System.EventArgs e)
    {
       
        await Navigation.PushModalAsync(new SignIn());
    }

    async void btn_switch2(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new MobileHome());
    }

}

