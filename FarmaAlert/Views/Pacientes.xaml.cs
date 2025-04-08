using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Maui.Controls;
using FarmaAlert.Models;
using FarmaAlert.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FarmaAlert.Pages
{
    public partial class PacientesPage : ContentPage, INotifyPropertyChanged
    {
        private ObservableCollection<PacientesModel> _pacientes;
        private ObservableCollection<PacientesModel> _pacientesFiltrados;
        private readonly PacienteService _pacienteService;

        public ObservableCollection<PacientesModel> Pacientes
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

        public PacientesPage()
        {
            InitializeComponent();
            _pacienteService = new PacienteService();
            Pacientes = new ObservableCollection<PacientesModel>();
            PacientesFiltrados = new ObservableCollection<PacientesModel>();
            BindingContext = this;
            CargarPacientes();
        }

        private async void CargarPacientes()
        {
            var pacientes = await _pacienteService.GetAllPacientes();

            Pacientes.Clear();
            foreach (var paciente in pacientes)
            {
                Pacientes.Add(paciente);
            }

            FiltrarPacientes("");
        }

        private void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
        {
            FiltrarPacientes(e.NewTextValue);
        }

        private void FiltrarPacientes(string filtro)
        {
            filtro = filtro?.ToLower() ?? "";

            PacientesFiltrados = new ObservableCollection<PacientesModel>(
                Pacientes.Where(p => p.NombrePaciente.ToLower().Contains(filtro))
            );
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
