using FarmaAlert.Views;

namespace FarmaAlert.Pages;

public partial class Pastillas : ContentPage
{
    private bool _opcionesVisibles = false;

    public Pastillas()
    {
        InitializeComponent();
        LoadAlarms();
    }

    private void LoadAlarms()
    {
        var alarms = new List<Alarma>
        {
            new Alarma { Name = "Paracetamol", Amount=0.5, Time = "08:00 AM", Frequency = "Diario", Paciente="Alicia Jaqueline Bosques", Habitacion=5},
            new Alarma { Name = "Ibuprofeno", Amount=1, Time = "02:00 PM", Frequency = "Cada 12 horas", Paciente="Julio Enrique Polanco", Habitacion=3},
            new Alarma { Name = "Ibuprofeno", Amount=1, Time = "02:00 PM", Frequency = "Cada 12 horas", Paciente="Kevin Adrian Soto", Habitacion=4 }
        };
        AlarmasList.ItemsSource = alarms;
    }

    private async void OnCerrarSesionClicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new login()); // Reemplaza AppShell por la pantalla de Login
    }

    private void OnAgregarClicked(object sender, EventArgs e)
    {
        _opcionesVisibles = !_opcionesVisibles;
        OpcionesAgregar.IsVisible = _opcionesVisibles;
    }

    private async void OnNuevaAlarmaClicked(object sender, EventArgs e)
    {
        OpcionesAgregar.IsVisible = false;
        _opcionesVisibles = false;
        await Navigation.PushAsync(new AgregarAlarma());
    }

    private async void OnDispensarClicked(object sender, EventArgs e)
    {
        OpcionesAgregar.IsVisible = false;
        _opcionesVisibles = false;
        await Navigation.PushAsync(new DispensarPastilla()); // Debes crear esta página
    }

    private async void OnAlarmaSeleccionada(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Alarma alarmaSeleccionada)
        {
            await Navigation.PushAsync(new AgregarAlarma()); // Debes crear esta página
        }
    }

    private async void OnEliminarAlarma(object sender, EventArgs e)
    {
        var boton = sender as Button;
        if (boton?.CommandParameter is Alarma alarmaSeleccionada)
        {
            bool confirmacion = await DisplayAlert("Eliminar", $"¿Deseas eliminar la alarma {alarmaSeleccionada.Name}?", "Sí", "No");
            if (confirmacion)
            {
                var lista = (List<Alarma>)AlarmasList.ItemsSource;
                lista.Remove(alarmaSeleccionada);
                AlarmasList.ItemsSource = null;
                AlarmasList.ItemsSource = lista;
            }
        }
    }
}

public class Alarma
{
    public string Name { get; set; }
    public string Time { get; set; }
    public string Frequency { get; set; }
    public double Amount { get; set; }
    public string Paciente { get; set; }
    public int Habitacion { get; set; }
}
