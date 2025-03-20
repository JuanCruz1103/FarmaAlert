using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FarmaAlert.ViewModel
{
    public class StatisticsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Estadistica> Estadisticas { get; set; }
        public ObservableCollection<string> Filtros { get; set; }
        public string FiltroSeleccionado { get; set; }

        public ICommand FiltrarDatos { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public StatisticsViewModel()
        {
            Filtros = new ObservableCollection<string> { "Semana", "Paciente" };
            FiltroSeleccionado = "Semana";
            FiltrarDatos = new Command(AplicarFiltro);
            CargarDatos();
        }

        private void CargarDatos()
        {
            Estadisticas = new ObservableCollection<Estadistica>
        {
            new Estadistica { Categoria = "Pastillas Tomadas", Cantidad = 6 },
            new Estadistica { Categoria = "Pastillas No Tomadas", Cantidad = 1 }
        };
            OnPropertyChanged(nameof(Estadisticas));
        }

        private void AplicarFiltro()
        {
            Estadisticas.Clear();
            if (FiltroSeleccionado == "Semana")
            {
                Estadisticas = new ObservableCollection<Estadistica>
            {
                new Estadistica { Categoria = "Pastillas Tomadas", Cantidad = 6 },
                new Estadistica { Categoria = "Pastillas No Tomadas", Cantidad = 1 }
            };
            }
            else if (FiltroSeleccionado == "Paciente")
            {
                Estadisticas = new ObservableCollection<Estadistica>
            {
                new Estadistica { Categoria = "Paciente A", Cantidad = 4 },
                new Estadistica { Categoria = "Paciente B", Cantidad = 3 }
            };
            }
            OnPropertyChanged(nameof(Estadisticas));
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public class Estadistica
    {
        public string Categoria { get; set; }
        public int Cantidad { get; set; }
    }

}
