using System.ComponentModel.DataAnnotations;

namespace MiAPI.UTN._001.Models
{
    public class Empleado
    {
        [Key]
        public int Id { get; set; } //PK


        public double Salario { get; set; }
        public double Comision {  get; set; }

        public DateTime FechaIngreso { get; set; }



        //Relaciones 

   
        public int PersonaId { get; set; } //FK a Perosna 

        public Persona? Persona { get; set; }



        public int CargoId { get; set; }  //FK a Cargo
        public Cargo? Cargo { get; set; }  //objetos de navegacion 





    }
}
