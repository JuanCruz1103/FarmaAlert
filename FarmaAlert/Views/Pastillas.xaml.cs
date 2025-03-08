
namespace FarmaAlert.Pages;

public partial class Pastillas : ContentPage
{
    public Pastillas()
    {
        InitializeComponent();
        LoadAlarms();
    }
    private void LoadAlarms()
    {
        // Simulación de datos de alarmas
        var alarms = new List<Alarma>
            {
                new Alarma { Name = "Paracetamol", Amount=0.5, Time = "08:00 AM", Frequency = "Diario", Paciente="Alicia Jaqueline Bosques", Habitacion=5},
                new Alarma { Name = "Ibuprofeno", Amount=1,Time = "02:00 PM", Frequency = "Cada 12 horas", Paciente="Julio Enrique Polanco", Habitacion=3},
                new Alarma { Name = "Ibuprofeno", Amount=1, Time = "02:00 PM", Frequency = "Cada 12 horas", Paciente="Kevin Adrian Soto", Habitacion=4 }
            };
        AlarmasList.ItemsSource= alarms;
    }

    public async void OnAgregarClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AgregarAlarma());
    }
    
    public async void OnOpcionesClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new conexion());
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