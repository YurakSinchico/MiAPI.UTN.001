using Api.Consummer;

using MiApp.UTN.Modelos;

namespace MiApp.Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Crud<Cargo>.Endpoint = "https://localhost:5051/api/cargo";
            var nuevoCargo = new Cargo { Description = "Cargo de prueba", Name = "Prueba" };
            nuevoCargo = Crud<Cargo>.Create(nuevoCargo);
        }
    }
}