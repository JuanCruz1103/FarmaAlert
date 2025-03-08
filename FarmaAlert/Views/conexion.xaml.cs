namespace FarmaAlert.Pages;

public partial class conexion : ContentPage
{
	public conexion()
	{
		InitializeComponent();
	}

	public async void OnAgregarClicked(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new BuscarDispositivo());
    }
    public async void OnDetalleClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DetalleVinculo());
    }
}