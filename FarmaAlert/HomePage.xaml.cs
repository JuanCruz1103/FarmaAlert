namespace FarmaAlert;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
        LoadAlarms();
	}
    private void LoadAlarms()
    {
        // Simulación de datos de alarmas
        var alarms = new List<Alarma>
            {
                new Alarma { Name = "Paracetamol", Amount=0.5, Time = "08:00 AM", Frequency = "Diario" },
                new Alarma { Name = "Ibuprofeno", Amount=1,Time = "02:00 PM", Frequency = "Cada 12 horas" },
                new Alarma { Name = "Ibuprofeno", Amount=1, Time = "02:00 PM", Frequency = "Cada 12 horas" }
            };
        AlarmasList.ItemsSource = alarms;
    }
}

public class Alarma
{
    public string Name { get; set; }
    public string Time { get; set; }
    public string Frequency { get; set; }
    public double Amount { get; set; }
}