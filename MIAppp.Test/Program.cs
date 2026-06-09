using Api.Consummer;

using MiApp.UTN.Modelos;

namespace MiApp.Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Crud<Cargo>.Endpoint = "https://localhost:7188/api/Cargos";   
            Crud <Persona>.Endpoint = "https://localhost:7188/api/Personas";
            //var nuevoCargo = Crud<Cargo>.Create(new Cargo
            //{
            //    Description = "Cargo prueba",
            //    Name = "Peueba"
            //});

            //var nuevaPersona = Crud<Persona>.Create(new Persona
            //{
            //    Nombre = "Juan",
            //    Apellido = "Perez",
            //    Direccion = "Calle plata 123",
            //    Email = "abc@gamil.com",
            //    Telefono = "12345567"
            //});

            Crud<Cargo>.Delete("1");
            Console.ReadLine();
        }
    }
}