using FarmaAlert.Views;
using FarmaAlert.Models;
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
        var alarms = new List<AlarmaModel>
        {
            new AlarmaModel { Name = "Paracetamol", Amount=0.5, Time = "08:00 AM", Frequency = "Diario", Paciente="Alicia Jaqueline Bosques", Habitacion=5},
            new AlarmaModel { Name = "Ibuprofeno", Amount=1, Time = "02:00 PM", Frequency = "Cada 12 horas", Paciente="Julio Enrique Polanco", Habitacion=3},
            new AlarmaModel { Name = "Ibuprofeno", Amount=1, Time = "02:00 PM", Frequency = "Cada 12 horas", Paciente="Kevin Adrian Soto", Habitacion=4 },
            new AlarmaModel { Name = "Paracetamol", Amount = 2, Time = "08:00 AM", Frequency = "Cada 8 horas", Paciente = "María González", Habitacion = 5 },
            new AlarmaModel { Name = "Amoxicilina", Amount = 1, Time = "10:00 AM", Frequency = "Cada 12 horas", Paciente = "Juan Pérez", Habitacion = 2 },
            new AlarmaModel { Name = "Metformina", Amount = 1, Time = "07:00 AM", Frequency = "Cada 24 horas", Paciente = "Ana López", Habitacion = 3 },
            new AlarmaModel { Name = "Aspirina", Amount = 1, Time = "03:00 PM", Frequency = "Cada 6 horas", Paciente = "Luis Martínez", Habitacion = 1 },
            new AlarmaModel { Name = "Loratadina", Amount = 1, Time = "09:00 PM", Frequency = "Cada 24 horas", Paciente = "Sofía Ramírez", Habitacion = 6 },
            new AlarmaModel { Name = "Ciprofloxacino", Amount = 1, Time = "01:00 PM", Frequency = "Cada 12 horas", Paciente = "Carlos Fernández", Habitacion = 7 },
            new AlarmaModel { Name = "Omeprazol", Amount = 1, Time = "06:00 AM", Frequency = "Cada 24 horas", Paciente = "Patricia Torres", Habitacion = 8 }

        };
        AlarmasList.ItemsSource = alarms;
    }

    private async void OnCerrarSesionClicked(object sender, EventArgs e)
    {
        bool confirmacion = await DisplayAlert("Cerrar sesión", "¿Estás seguro de que deseas cerrar sesión?", "Sí", "No");
        if (confirmacion)
        {
            App.Current.MainPage = new NavigationPage(new login());
        }
    }

    private async void OnAgregarClicked(object sender, EventArgs e)
    {
        _opcionesVisibles = !_opcionesVisibles;
        OpcionesAgregar.IsVisible = _opcionesVisibles;

        if (_opcionesVisibles)
        {
            OpcionesAgregar.Opacity = 0;
            OpcionesAgregar.Scale = 0.8;

            await Task.WhenAll(
                OpcionesAgregar.FadeTo(1, 150),
                OpcionesAgregar.ScaleTo(1, 150, Easing.SpringOut)
            );
        }
    }

    private async void OnNuevaAlarmaClicked(object sender, EventArgs e)
    {
        OpcionesAgregar.IsVisible = false;
        _opcionesVisibles = false;

        // Ensure the AgregarAlarma page exists
        if (typeof(AgregarAlarma) != null)
        {
            await Navigation.PushAsync(new AgregarAlarma());
        }
        else
        {
            await DisplayAlert("Error", "La página para agregar alarmas no está disponible.", "OK");
        }
    }

    private async void OnDispensarClicked(object sender, EventArgs e)
    {
        OpcionesAgregar.IsVisible = false;
        _opcionesVisibles = false;

        // Ensure the DispensarPastilla page exists
        if (typeof(DispensarPastilla) != null)
        {
            await Navigation.PushAsync(new DispensarPastilla());
        }
        else
        {
            await DisplayAlert("Error", "La página para dispensar pastillas no está disponible.", "OK");
        }
    }

    private async void OnAlarmaSeleccionada(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is AlarmaModel alarmaSeleccionada)
        {
            // Reset selection
            ((CollectionView)sender).SelectedItem = null;

            // Check if EditarAlarma exists before navigatingx
            try
            {
                if (typeof(EditarAlarma) != null)
                {
                    await Navigation.PushAsync(new EditarAlarma(alarmaSeleccionada));
                }
                else
                {
                    // If EditarAlarma doesn't exist, create a temporary page
                    await Navigation.PushAsync(new EditarAlarma(alarmaSeleccionada));
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "No se pudo abrir la página de edición. " + ex.Message, "OK");
            }
        }
    }

    private async void OnEditarAlarma(object sender, EventArgs e)
    {
        var boton = sender as Button;
        if (boton?.CommandParameter is AlarmaModel alarmaSeleccionada)
        {
            // Animación de feedback al pulsar el botón
            await boton.ScaleTo(0.9, 50);
            await boton.ScaleTo(1, 50);

            try
            {
                if (typeof(EditarAlarma) != null)
                {
                    await Navigation.PushAsync(new EditarAlarma(alarmaSeleccionada));
                }
                else
                {
                    // Si EditarAlarma no existe, crear una página temporal
                    await Navigation.PushAsync(new EditarAlarma(alarmaSeleccionada));
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error de navegación",
                    "No se pudo abrir la página de edición. Se creará una temporal.", "OK");
                await Navigation.PushAsync(new EditarAlarma(alarmaSeleccionada));
            }
        }
    }

    private async void OnEliminarAlarma(object sender, EventArgs e)
    {
        var boton = sender as Button;
        if (boton?.CommandParameter is AlarmaModel alarmaSeleccionada)
        {
            bool confirmacion = await DisplayAlert("Eliminar", $"¿Deseas eliminar la alarma {alarmaSeleccionada.Name}?", "Sí", "No");
            if (confirmacion)
            {
                var lista = (List<AlarmaModel>)AlarmasList.ItemsSource;
                lista.Remove(alarmaSeleccionada);
                AlarmasList.ItemsSource = null;
                AlarmasList.ItemsSource = lista;

                await DisplayAlert("Éxito", $"La alarma {alarmaSeleccionada.Name} ha sido eliminada.", "OK");
            }
        }
    }
}

//// Temporal page for editing if EditarAlarma doesn't exist
//public class EditarAlarma : ContentPage
//{
//    public EditarAlarma(AlarmaModel alarma)
//    {
//        Title = "Editar Alarma";

//        var layout = new StackLayout
//        {
//            Padding = new Thickness(20),
//            Spacing = 15
//        };

//        layout.Children.Add(new Label
//        {
//            Text = "Editar Alarma",
//            FontSize = 24,
//            FontAttributes = FontAttributes.Bold,
//            HorizontalOptions = LayoutOptions.Center,
//            Margin = new Thickness(0, 0, 0, 20)
//        });

//        // Medication Name
//        layout.Children.Add(new Label { Text = "Nombre del medicamento:", FontAttributes = FontAttributes.Bold });
//        layout.Children.Add(new Entry { Text = alarma.Name, Placeholder = "Nombre del medicamento" });

//        // Time
//        layout.Children.Add(new Label { Text = "Hora:", FontAttributes = FontAttributes.Bold });
//        layout.Children.Add(new Entry { Text = alarma.Time, Placeholder = "Hora (ej: 08:00 AM)" });

//        // Frequency
//        layout.Children.Add(new Label { Text = "Frecuencia:", FontAttributes = FontAttributes.Bold });
//        layout.Children.Add(new Entry { Text = alarma.Frequency, Placeholder = "Frecuencia (ej: Diario)" });

//        // Amount
//        layout.Children.Add(new Label { Text = "Cantidad:", FontAttributes = FontAttributes.Bold });
//        layout.Children.Add(new Entry { Text = alarma.Amount.ToString(), Placeholder = "Cantidad" });

//        // Patient
//        layout.Children.Add(new Label { Text = "Paciente:", FontAttributes = FontAttributes.Bold });
//        layout.Children.Add(new Entry { Text = alarma.Paciente, Placeholder = "Nombre del paciente" });

//        // Room
//        layout.Children.Add(new Label { Text = "Habitación:", FontAttributes = FontAttributes.Bold });
//        layout.Children.Add(new Entry { Text = alarma.Habitacion.ToString(), Placeholder = "Número de habitación" });

//        // Save button
//        var saveButton = new Button
//        {
//            Text = "Guardar Cambios",
//            BackgroundColor = Color.Parse("#4CAF50"),
//            TextColor = Colors.White,
//            Margin = new Thickness(0, 20, 0, 0)
//        };

//        saveButton.Clicked += async (sender, e) => {
//            await DisplayAlert("Guardado", "Los cambios se guardarán cuando implemente la funcionalidad completa.", "OK");
//            await Navigation.PopAsync();
//        };

//        layout.Children.Add(saveButton);

//        Content = new ScrollView { Content = layout };
//    }
//}