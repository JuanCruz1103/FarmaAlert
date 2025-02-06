using FarmaAlert;

namespace FarmaAlert.Pages;

public partial class Register : ContentPage
{
    public Register()
    {
        InitializeComponent();
    }

    private async void Registerbtn_Clicked(object sender, EventArgs e)
    {
        await DisplayAlert("Success", "Registration successful", "OK");
        await Navigation.PopAsync();
    }

    private async void OnBackToLoginClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Success", "Registration successful", "OK");
        await Navigation.PopAsync(); // Regresar a la página anterior (Login)
    }

    private void Button_Unfocused(object sender, FocusEventArgs e)
    {

    }
}
