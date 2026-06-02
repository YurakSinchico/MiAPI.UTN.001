using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.UTN.Modelos
{
    public class EstadisticaSalario
    {
        public double SalarioMinimo { get; set; }
        public double SalarioMaximo { get; set; }
        public double SalarioPromedio { get; set; }
        public int CantidadEmpleados { get; set; }
        public double pagoTotal { get; set; }

        public string EmpleadoAntiguo { get; set; }
        public string EmpleadoReciente { get; set; }
    }
}
