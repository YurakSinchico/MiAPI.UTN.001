using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MiAppUTNModelos
{
    public class Cargo
    {

        [Key]
        public int Id { get; set; }  //Pk

        public string Name { get; set; }

        public string Description { get; set; }


        // Relaciones 

        public List<Empleado>? Empleado { get; set; }
    }
}
