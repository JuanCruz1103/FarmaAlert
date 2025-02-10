namespace FarmaAlert.Pages;

public partial class DetallePaciente : ContentPage
{
	public DetallePaciente(Paciente paciente)
	{
		InitializeComponent();

        NombreLabel.Text = paciente.Nombre;
        FechaNacimientoLabel.Text = paciente.FechaNacimiento.ToShortDateString();
        HabitacionLabel.Text = paciente.Habitacion;
        FechaRegistroLabel.Text = paciente.FechaRegistro.ToShortDateString();
        InformacionMedicaLabel.Text = paciente.InformacionMedica;
    }
}

// Clase de ejemplo para representar un paciente
public class Paciente
{
    public string Nombre { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public string Habitacion { get; set; }
    public DateTime FechaRegistro { get; set; }
    public string InformacionMedica { get; set; }
}