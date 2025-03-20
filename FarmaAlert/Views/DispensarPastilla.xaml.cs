namespace FarmaAlert.Views;

public partial class DispensarPastilla : ContentPage
{
    public DispensarPastilla()
    {
        InitializeComponent();
    }
    private void OnMedicamentoSelected(object sender, EventArgs e)
    {
        // Aquí puedes manejar la selección del medicamento si es necesario
    }

    private void OnDispensarClicked(object sender, EventArgs e)
    {
        string medicamento = MedicamentoPicker.SelectedItem?.ToString();
        string cantidadText = CantidadEntry.Text;

        if (string.IsNullOrEmpty(medicamento) || string.IsNullOrEmpty(cantidadText))
        {
            ResultadoLabel.Text = "Por favor, selecciona un medicamento y una cantidad.";
            return;
        }

        if (int.TryParse(cantidadText, out int cantidad))
        {
            // Aquí puedes agregar la lógica para dispensar el medicamento
            // Por ejemplo, registrar la dispensación en una base de datos

            ResultadoLabel.Text = $"Dispensadas {cantidad} de {medicamento}.";
        }
        else
        {
            ResultadoLabel.Text = "La cantidad debe ser un número válido.";
        }
    }
}
    