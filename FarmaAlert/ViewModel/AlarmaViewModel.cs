using FarmaAlert.Models;
using FarmaAlert.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace FarmaAlert.ViewModels
{
    public class AlarmaViewModel : BaseViewModel
    {
        private readonly AlarmaService _alarmaService;
        private ObservableCollection<AlarmaModel> _alarmas;
        private bool _isOpcionesVisible;
        private AlarmaModel _selectedAlarma;

        public ObservableCollection<AlarmaModel> Alarmas
        {
            get => _alarmas;
            set => SetProperty(ref _alarmas, value);
        }

        public bool IsOpcionesVisible
        {
            get => _isOpcionesVisible;
            set => SetProperty(ref _isOpcionesVisible, value);
        }

        public AlarmaModel SelectedAlarma
        {
            get => _selectedAlarma;
            set => SetProperty(ref _selectedAlarma, value);
        }

        public ICommand RefreshCommand { get; }
        public ICommand AgregarCommand { get; }
        public ICommand ToggleOpcionesCommand { get; }
        public ICommand NuevaAlarmaCommand { get; }
        public ICommand DispensarCommand { get; }
        public ICommand EditarAlarmaCommand { get; }
        public ICommand EliminarAlarmaCommand { get; }
        public ICommand CerrarSesionCommand { get; }

        public AlarmaViewModel(AlarmaService alarmaService)
        {
            //Titel = "Inicio";
            _alarmaService = alarmaService;
            Alarmas = new ObservableCollection<AlarmaModel>();

            RefreshCommand = new Command(async () => await LoadAlarmas());
            AgregarCommand = new Command(OnAgregar);
            ToggleOpcionesCommand = new Command(ToggleOpciones);
            NuevaAlarmaCommand = new Command(OnNuevaAlarma);
            DispensarCommand = new Command(OnDispensar);
            EditarAlarmaCommand = new Command<AlarmaModel>(OnEditarAlarma);
            EliminarAlarmaCommand = new Command<AlarmaModel>(async (alarma) => await OnEliminarAlarma(alarma));
            CerrarSesionCommand = new Command(OnCerrarSesion);
        }

        public async Task LoadAlarmas()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Alarmas.Clear();
                var alarmas = await _alarmaService.GetAllAlarmas();

                foreach (var alarma in alarmas)
                {
                    // Ya no es necesario asignar propiedades adicionales
                    Alarmas.Add(alarma);
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"No se pudieron cargar las alarmas: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void OnAgregar()
        {
            IsOpcionesVisible = !IsOpcionesVisible;
        }

        private void ToggleOpciones()
        {
            IsOpcionesVisible = !IsOpcionesVisible;
        }

        private async void OnNuevaAlarma()
        {
            IsOpcionesVisible = false;
            await Shell.Current.GoToAsync("AgregarAlarma");
        }

        private async void OnDispensar()
        {
            IsOpcionesVisible = false;
            await Shell.Current.DisplayAlert("Dispensar", "Función de dispensar pastilla", "OK");
        }

        private async void OnEditarAlarma(AlarmaModel alarma)
        {
            if (alarma == null)
                return;

            await Shell.Current.GoToAsync($"EditarAlarma?id={alarma.IdAlarma}");
        }

        private async Task OnEliminarAlarma(AlarmaModel alarma)
        {
            if (alarma == null)
                return;

            bool confirm = await Shell.Current.DisplayAlert("Confirmar", "¿Está seguro de eliminar esta alarma?", "Sí", "No");
            if (confirm)
            {
                IsBusy = true;
                bool deleted = await _alarmaService.DeleteAlarma(alarma.IdAlarma);
                IsBusy = false;

                if (deleted)
                {
                    Alarmas.Remove(alarma);
                    await Shell.Current.DisplayAlert("Éxito", "Alarma eliminada correctamente", "OK");
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "No se pudo eliminar la alarma", "OK");
                }
            }
        }

        private async void OnCerrarSesion()
        {
            bool confirm = await Shell.Current.DisplayAlert("Confirmar", "¿Está seguro de cerrar sesión?", "Sí", "No");
            if (confirm)
            {
                // Lógica para cerrar sesión
                await Shell.Current.GoToAsync("login");
            }
        }
    }
}