using System.ComponentModel.DataAnnotations;

namespace MiAPI.UTN._001.Models
{
    public class Persona
    {

        [Key]
        public int Id { get; set; } //Pk


        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Email { get; set; }

        public string Telefono { get; set; }

        public string Direccion { get; set; }


        //Relaciones

        public Empleado? Empleado { get; set; }




    }
}
