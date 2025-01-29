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

    private async void Loginbtn_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new Register());

    }

}