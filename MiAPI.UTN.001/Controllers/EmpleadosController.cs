using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiAPI.UTN._001.Data;
using MiApp.UTN.Modelos;

namespace MiAPI.UTN._001.Controllers
{
    [Route("api/[controller]")]  //este controlador tiene la ruta del api y la ruta que le corrsponder 
    [ApiController]              //buscara todas las operaciones de open apii estas dos anotaciones son importantes
    public class EmpleadosController : ControllerBase
    {
        private readonly MiAPIUTN_001Context _context;   //el objeto del contexto del dbcontext es la clase que me conecta directamente a la base de datos

        public EmpleadosController(MiAPIUTN_001Context context)
        {
            _context = context;
        }

        //para calcular campos hacemos esto

        [HttpGet("EstadisticaSalarios")]

        public async Task<ActionResult<EstadisticaSalarios>> EstadisticaSalarios()
        {
            var salarioMaximo = await _context.Empleados.MaxAsync(e => e.Salario + e.Comision);
            var salarioMinimo = await _context.Empleados.MinAsync(e => e.Salario + e.Comision);
            var salarioPromedio = await _context.Empleados.AverageAsync(e => e.Salario + e.Comision);
            var cantidadEmpleados = await _context.Empleados.CountAsync();
            var pagoTotal = await _context.Empleados.SumAsync(e => e.Salario +e.Comision);


       
            var empleadoAntiguo = await _context.Empleados
                .Include(e => e.Persona)
                   .OrderBy (e => e.FechaIngreso)
                   .FirstOrDefaultAsync();

            var empleadoReciente = await _context .Empleados 
                .Include(e => e.Persona)
                .OrderByDescending(e => e.FechaIngreso)
                .FirstOrDefaultAsync();

            var resultado = new EstadisticaSalarios
            {
                SalarioMaximo = salarioMaximo,
                SalarioMinimo = salarioMinimo,
                SalarioPromedio = salarioMinimo,
                CantidadEmpleados = cantidadEmpleados,
                PagoTotal=pagoTotal,
                EmpleadoAntiguo = empleadoAntiguo != null ? $"{empleadoAntiguo.Persona.Nombre}{empleadoAntiguo.Persona.Apellido}" : "N/A",
                EmpleadoReciente = empleadoAntiguo != null ? $"{empleadoReciente.Persona.Nombre}{empleadoReciente.Persona.Apellido}" : "N/A"

            };

            return resultado ;

        }

        //

        // GET: api/Empleados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleado()
        {
            return await _context.Empleados.ToListAsync();
        }

        // GET: api/Empleados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>> GetEmpleado(int id) // de froma asincronica me conecto a la base de datos 
        {
            var empleado = await _context
                .Empleados
                .Include(e => e.Persona)  //expresiones landa 
                .Include(e => e.Cargo)
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();

            if (empleado == null)
            {
                return NotFound(); // es el numero 4000 de la base de datos 
            }

            return empleado;
        }

        // PUT: api/Empleados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleado(int id, Empleado empleado)
        {
            if (id != empleado.Id)
            {
                return BadRequest(); //error 400
            }

            _context.Entry(empleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent(); //devuelvo nada de resultados , la actualizacion no devuelve datos 
        }

        // POST: api/Empleados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Empleado>> PostEmpleado(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpleado", new { id = empleado.Id }, empleado);
        }

        // DELETE: api/Empleados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }

            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpleadoExists(int id)
        {
            return _context.Empleados.Any(e => e.Id == id);
        }
    }
}
