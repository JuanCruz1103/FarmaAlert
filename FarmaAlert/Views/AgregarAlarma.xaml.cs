
namespace FarmaAlert.Pages;

public partial class AgregarAlarma : ContentPage
{
	public AgregarAlarma()
	{
		InitializeComponent();
	}


    private async void OnGuardarAlarmaClicked(object sender, EventArgs e)
    {
        // Obtener los valores de los campos
        string nombrePastilla = NombrePastillaEntry.Text;
        TimeSpan hora = HoraTimePicker.Time;
        DateTime fechaFin = FechaFinDatePicker.Date;
        string frecuencia = FrecuenciaPicker.SelectedItem?.ToString();
        string dosis = DosisEntry.Text;
        string paciente = PacienteEntry.Text;
        string habitacion = HabitacionEntry.Text;
        string instrucciones = InstruccionesEditor.Text;

        // Validar que todos los campos estén llenos
        if (string.IsNullOrWhiteSpace(nombrePastilla) ||
            string.IsNullOrWhiteSpace(frecuencia) ||
            string.IsNullOrWhiteSpace(dosis) ||
            string.IsNullOrWhiteSpace(paciente) ||
            string.IsNullOrWhiteSpace(habitacion))
        {
            DisplayAlert("Error", "Por favor, complete todos los campos obligatorios.", "OK");
            return;
        }

        // Aquí guardariamos los datos en una colección de mongo
        // Por ahora, solo simulamos que todo salio bien
        DisplayAlert("Éxito", "Alarma guardada correctamente.", "OK");

        // Limpiar los campos después de supuestamente guardar
        NombrePastillaEntry.Text = string.Empty;
        HoraTimePicker.Time = TimeSpan.Zero;
        FechaFinDatePicker.Date = DateTime.Today;
        FrecuenciaPicker.SelectedIndex = -1;
        DosisEntry.Text = string.Empty;
        PacienteEntry.Text = string.Empty;
        HabitacionEntry.Text = string.Empty;
        InstruccionesEditor.Text = string.Empty;

        await Navigation.PushAsync(new Pastillas());
    }
}