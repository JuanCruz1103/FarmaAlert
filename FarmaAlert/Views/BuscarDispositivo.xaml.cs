namespace FarmaAlert.Pages;

public partial class BuscarDispositivo : ContentPage
{
	public BuscarDispositivo()
	{
		InitializeComponent();
	}

    public async void OnAgregarClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new VincularDispositivo());
    }
}