using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaAlert.Models
{
    public class AlarmaModel
    {
        public string Name { get; set; }
        public string Time { get; set; }
        public string Frequency { get; set; }
        public double Amount { get; set; }
        public string Paciente { get; set; }
        public int Habitacion { get; set; }
    }
}
