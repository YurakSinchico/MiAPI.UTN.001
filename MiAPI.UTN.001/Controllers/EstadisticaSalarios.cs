namespace MiAPI.UTN._001.Controllers
{
    public class EstadisticaSalarios
    {
        public double SalarioMinimo { get; set; }

        public double SalarioMaximo { get; set; }
        public double SalarioPromedio { get; set; }

        public int CantidadEmpleados { get; set; }
        public string EmpleadoAntiguo { get; set; } 
        public string EmpleadoReciente {  get; set; }
        public double PagoTotal { get; set; }

    }
}
