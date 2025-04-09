// DispensarPastilla.xaml.cs
using FarmaAlert.Services;

namespace FarmaAlert.Pages;

public partial class DispensarPastilla : ContentPage
{
    private readonly DispensadorService _dispensadorService;

    public DispensarPastilla()
    {
        InitializeComponent();
        _dispensadorService = new DispensadorService();
    }

    private async void OnDispensarClicked(object sender, EventArgs e)
    {
        if (MedicamentoPicker.SelectedItem == null)
        {
            await DisplayAlert("Error", "Por favor seleccione un medicamento", "OK");
            return;
        }

        if (string.IsNullOrEmpty(DispensadorNameEntry.Text))
        {
            await DisplayAlert("Error", "Por favor ingrese el nombre del dispensador", "OK");
            return;
        }

        string medicamento = MedicamentoPicker.SelectedItem.ToString();
        string dispensadorNombre = DispensadorNameEntry.Text;

        try
        {
            bool success = await _dispensadorService.ActivarDispensador(dispensadorNombre);

            //if (success)
            //{
                ResultadoLabel.Text = $"Activando {dispensadorNombre} para {medicamento}";
                ResultadoLabel.TextColor = Colors.Green;

                // Volver a la página anterior
                await Navigation.PopAsync();
            //}
            //else
            //{
            //    ResultadoLabel.Text = "Error al activar el dispensador";
            //    ResultadoLabel.TextColor = Colors.Red;
            //}
        }
        catch (Exception ex)
        {
            ResultadoLabel.Text = $"Error: {ex.Message}";
            ResultadoLabel.TextColor = Colors.Red;
            await DisplayAlert("Error", $"No se pudo activar: {ex.Message}", "OK");
        }
    }

    private void OnMedicamentoSelected(object sender, EventArgs e)
    {
        // Mantenemos esta función vacía por si el XAML la necesita
    }
}