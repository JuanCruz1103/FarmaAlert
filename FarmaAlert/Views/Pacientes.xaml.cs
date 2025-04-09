using System.Collections.ObjectModel;
using FarmaAlert.Models;
using FarmaAlert.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FarmaAlert.Pages
{
    public partial class Pacientes : ContentPage, INotifyPropertyChanged
    {
        private ObservableCollection<PacientesModel> _pacientes;
        private ObservableCollection<PacientesModel> _pacientesFiltrados;
        private readonly PacienteService _pacienteService;
        private bool _isLoading;

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<PacientesModel> PacientesPage
        {
            get => _pacientes;
            set
            {
                _pacientes = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<PacientesModel> PacientesFiltrados
        {
            get => _pacientesFiltrados;
            set
            {
                _pacientesFiltrados = value;
                OnPropertyChanged();
            }
        }

        public Pacientes()
        {
            InitializeComponent();
            _pacienteService = new PacienteService();
            PacientesPage = new ObservableCollection<PacientesModel>();
            PacientesFiltrados = new ObservableCollection<PacientesModel>();
            BindingContext = this;
            
            // Cargar pacientes cuando la página aparezca
            this.Appearing += (s, e) => CargarPacientes();
        }

        private async void CargarPacientes()
        {
            try
            {
                IsLoading = true;
                
                var pacientes = await _pacienteService.GetAllPacientes();
                
                // Actualiza en el hilo principal
                MainThread.BeginInvokeOnMainThread(() => {
                    PacientesPage.Clear();
                
                    foreach (var paciente in pacientes)
                    {
                        PacientesPage.Add(paciente);
                    }
                
                    // Actualizamos la lista filtrada
                    FiltrarPacientes(searchBar.Text);
                    
                    // Debug info
                    Console.WriteLine($"Pacientes cargados: {PacientesPage.Count}");
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar pacientes: {ex}");
            }
            finally
            {
                IsLoading = false;
            }
        }

        private void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
        {
            FiltrarPacientes(e.NewTextValue);
        }

        private void FiltrarPacientes(string filtro)
        {
            try
            {
                filtro = filtro?.ToLower() ?? "";
                
                // Limpia y vuelve a llenar la colección existente en lugar de crear una nueva
                PacientesFiltrados.Clear();
                
                var pacientesFiltrados = PacientesPage
                    .Where(p => string.IsNullOrEmpty(filtro) || 
                                p.NombrePaciente.ToLower().Contains(filtro))
                    .ToList();
                
                foreach (var paciente in pacientesFiltrados)
                {
                    PacientesFiltrados.Add(paciente);
                }
                
                Console.WriteLine($"Pacientes filtrados: {PacientesFiltrados.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al filtrar: {ex}");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}