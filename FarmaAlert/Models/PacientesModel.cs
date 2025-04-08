using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaAlert.Models
{
    public class PacientesModel
    {
        public string IdPaciente { get; set; }
        public string IdPastillero { get; set; }
        public string NombrePaciente { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string HabitacionPaciente { get; set; }
        public string EstadoPaciente { get; set; }
        public string? InformacionMedica { get; set; }
        public DateTime FechaIngreso { get; set; }
    }
}
