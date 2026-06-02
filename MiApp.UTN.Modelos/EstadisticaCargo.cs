using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.UTN.Modelos
{
    public class EstadisticaCargo
    {
        public string Cargo { get; set; }

        public int CantidadEmpleados { get; set; }
        public double SalarioTotal { get; set; }
        public double SalarioPromedio { get; set; }
    }
}
