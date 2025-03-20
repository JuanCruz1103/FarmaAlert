using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Microsoft.Maui.Controls;
using FarmaAlert.Models;

namespace FarmaAlert.Pages
{
    public partial class PacientesPage : ContentPage
    {
        public ObservableCollection<PacientesModel> Paciente { get; set; }
        public ObservableCollection<PacientesModel> PacientesFiltrados { get; set; }

        public PacientesPage()
        {
            InitializeComponent();
            Paciente = ObtenerPacientes();
            PacientesFiltrados = new ObservableCollection<PacientesModel>(Paciente);
            BindingContext = this;
        }

        private ObservableCollection<PacientesModel> ObtenerPacientes()
        {
            return new ObservableCollection<PacientesModel>
            {
                new PacientesModel { Nombre = "Alicia Jaqueline", Habitacion = "101", FechaRegistro=new DateTime(1980, 8, 12), FechaNacimiento = new DateTime(1950, 5, 10), InformacionMedica = "Diabetes tipo 2", Foto="dotnet_bot.png" },
                new PacientesModel { Nombre = "María Teresa", Habitacion = "102", FechaRegistro=new DateTime(1980, 8, 12), FechaNacimiento = new DateTime(1945, 8, 22), InformacionMedica = "Hipertensión arterial", Foto="paciente1.png" },

            };
        }

        private void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
        {
            string filtro = e.NewTextValue?.ToLower() ?? string.Empty;

            PacientesFiltrados.Clear();
            foreach (var paciente in Paciente.Where(p => p.Nombre.ToLower().Contains(filtro)))
            {
                PacientesFiltrados.Add(paciente);
            }
        }
    }
}
