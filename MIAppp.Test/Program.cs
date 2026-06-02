using Api.Consumer;

using MiApp.UTN.Modelos;

namespace MiApp.Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Crud<Cargo>.Endpoint = "https://localhost:8000/api/cargo";
            var nuevoCargo = new Cargo { Description = "Cargo de prueba", Name = "Prueba" };
            nuevoCargo = Crud<Cargo>.Create(nuevoCargo);
        }
    }
}