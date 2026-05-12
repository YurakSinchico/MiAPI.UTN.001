using System.ComponentModel.DataAnnotations;

namespace MiAPI.UTN._001.Models
{
    public class Cargo
    {

        [Key]
        public int Id { get; set; }  //Pk

        public string Name { get; set; }

        public string Description{ get; set; }


        // Relaciones 

        public List <Empleado>? Empleado {  get; set; } 
    }
}
