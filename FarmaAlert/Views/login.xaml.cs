using FarmaAlert;

namespace FarmaAlert.Pages;

public partial class login : ContentPage
{
	public login()
	{
		InitializeComponent();
	}

    private async void mainpage_Clicked(object sender, EventArgs e)
    {

        bool isLoginSuccessful = true;

        if (isLoginSuccessful)
        {
            // Navegar a HomePage (TabbedPage)
            await Navigation.PushAsync(new AppShell());
        }
        else
        {
            await DisplayAlert("Error", "Contraseña Invalida", "OK");
        }
    }


    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Register());
    }

    private async void OnForgotPasswordClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new recoberPassword());

    }

    private void ContentPage_NavigatedFrom(object sender, NavigatedFromEventArgs e)
    {

    }
}