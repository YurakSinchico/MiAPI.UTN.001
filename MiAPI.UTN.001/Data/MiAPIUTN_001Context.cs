using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiApp.UTN.Modelos;

namespace MiAPI.UTN._001.Data
{
    public class MiAPIUTN_001Context : DbContext
    {
        public MiAPIUTN_001Context (DbContextOptions<MiAPIUTN_001Context> options)
            : base(options)
        {
        }

        public DbSet<Cargo> Cargos { get; set; } = default!;
        public DbSet<Persona> Personas { get; set; } = default!;
        public DbSet<Empleado> Empleados { get; set; } = default!;
    }
}
