using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaAlert.Models
{
    public class PacientesModel
    {
        public int IdPaciente { get; set; }
        public string Nombre { get; set; }
        public string Habitacion { get; set; }
        public string Foto { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string InformacionMedica { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
