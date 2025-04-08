using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaAlert.Models
{
    public class AlarmaModel
    {
        public string IdAlarma { get; set; }
        public string IdPaciente { get; set; }
        public string NombreMedicamento { get; set; }
        public string IdUsuario { get; set; }
        public double DosisMg { get; set; }
        public int FrecuenciaHoras { get; set; }
        public DateTime FechaInicioTratamiento { get; set; }
        public DateTime FechaFinTratamiento { get; set; }
        public string Instrucciones { get; set; }
        public bool EstadoAlarma { get; set; }
    }
}
