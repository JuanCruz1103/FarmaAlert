namespace FarmaAlert.Pages;

public partial class Pacientes : ContentPage
{
    public Pacientes()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            // Assuming you have a Paciente object to pass
            Paciente paciente = GetSelectedPaciente();
            await Navigation.PushAsync(new DetallePaciente(paciente));
        }
    }

    private Paciente GetSelectedPaciente()
    {
        // Implement this method to return the selected Paciente object
        // For example, you might retrieve it from a list or a database
        return new Paciente
        {
            Nombre = "Juan Pérez",
            FechaNacimiento = new DateTime(1985, 5, 15),
            Habitacion = "101",
            FechaRegistro = DateTime.Now,
            InformacionMedica = "Alergia a la penicilina. Historial de hipertensión."
        };
    }
}
