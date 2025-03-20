using FarmaAlert.Models;
namespace FarmaAlert.Views
{
    public partial class EditarAlarma : ContentPage
    {
        private AlarmaModel _alarma;

        public EditarAlarma(AlarmaModel alarma)
        {
            InitializeComponent();
            _alarma = alarma;

            // Cargar los datos de la alarma en los campos
            NameEntry.Text = alarma.Name;
            TimeEntry.Text = alarma.Time;
            FrequencyEntry.Text = alarma.Frequency;
            AmountEntry.Text = alarma.Amount.ToString();
            PacienteEntry.Text = alarma.Paciente;
            HabitacionEntry.Text = alarma.Habitacion.ToString();
        }

        private async void OnGuardarClicked(object sender, EventArgs e)
        {
            // Guardar los cambios realizados
            _alarma.Name = NameEntry.Text;
            _alarma.Time = TimeEntry.Text;
            _alarma.Frequency = FrequencyEntry.Text;
            _alarma.Amount = double.TryParse(AmountEntry.Text, out double amount) ? amount : 0;
            _alarma.Paciente = PacienteEntry.Text;
            _alarma.Habitacion = int.TryParse(HabitacionEntry.Text, out int habitacion) ? habitacion : 0;

            // Aquí puedes agregar lógica para guardar los datos (por ejemplo, a la base de datos o a una lista)

            await DisplayAlert("Éxito", "Los cambios se guardaron correctamente.", "Aceptar");
            await Navigation.PopAsync(); // Regresar a la pantalla anterior
        }
    }
}
