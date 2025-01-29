namespace FarmaAlert;

public partial class login : ContentPage
{
	public login()
	{
		InitializeComponent();
	}

    private void mainpage_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }
}