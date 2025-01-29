namespace FarmaAlert;

public partial class Register : ContentPage
{
	public Register()
	{
		InitializeComponent();
	}

	private void Registerbtn_Clicked(object sender, EventArgs e)
	{
		

	}

    private async void OnBackToLoginClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

}