using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiAPI.UTN._001.Models;

namespace MiAPI.UTN._001.Data
{
    public class MiAPIUTN_001Context : DbContext
    {
        public MiAPIUTN_001Context (DbContextOptions<MiAPIUTN_001Context> options)
            : base(options)
        {
        }

        public DbSet<MiAPI.UTN._001.Models.Cargo> Cargos { get; set; } = default!;
        public DbSet<MiAPI.UTN._001.Models.Persona> Personas { get; set; } = default!;
        public DbSet<MiAPI.UTN._001.Models.Empleado> Empleados { get; set; } = default!;
    }
}
