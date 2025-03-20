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
                new PacientesModel { Nombre = "Alicia Jaqueline", Habitacion = "101", FechaRegistro=new DateTime(1980, 8, 12), FechaNacimiento = new DateTime(1950, 5, 10), InformacionMedica = "Diabetes tipo 2", Foto="pacoente2.png" },
                new PacientesModel { Nombre = "María Teresa", Habitacion = "102", FechaRegistro=new DateTime(1980, 8, 12), FechaNacimiento = new DateTime(1945, 8, 22), InformacionMedica = "Hipertensión arterial", Foto="paciente1.png" },
                new PacientesModel { Nombre = "Juan Carlos", Habitacion = "201", FechaRegistro = new DateTime(1990, 5, 15), FechaNacimiento = new DateTime(1985, 3, 10), InformacionMedica = "Diabetes tipo 2", Foto = "pacoente2.png" },
                new PacientesModel { Nombre = "Sofía Martínez", Habitacion = "303", FechaRegistro = new DateTime(1975, 9, 20), FechaNacimiento = new DateTime(1970, 4, 5), InformacionMedica = "Asma", Foto = "paciente1.png" },
                new PacientesModel { Nombre = "Carlos Alberto", Habitacion = "150", FechaRegistro = new DateTime(1985, 1, 10), FechaNacimiento = new DateTime(1960, 11, 30), InformacionMedica = "Enfermedad cardíaca", Foto = "pacoente2.png" },
                new PacientesModel { Nombre = "Ana Lucía", Habitacion = "404", FechaRegistro = new DateTime(2000, 2, 25), FechaNacimiento = new DateTime(1995, 6, 18), InformacionMedica = "Alergias estacionales", Foto = "paciente1.png" },
                new PacientesModel { Nombre = "Luis Fernando", Habitacion = "505", FechaRegistro = new DateTime(1988, 12, 5), FechaNacimiento = new DateTime(1983, 7, 22), InformacionMedica = "Artritis", Foto = "pacoente2.png" },
                new PacientesModel { Nombre = "Johanna Gómez", Habitacion = "607", FechaRegistro = new DateTime(1995, 3, 30), FechaNacimiento = new DateTime(1990, 9, 12), InformacionMedica = "Hipertensión", Foto = "paciente1.png" },
                new PacientesModel { Nombre = "Fernando Ruiz", Habitacion = "708", FechaRegistro = new DateTime(1982, 7, 19), FechaNacimiento = new DateTime(1978, 2, 14), InformacionMedica = "Colesterol alto", Foto = "pacoente2.png" }

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
