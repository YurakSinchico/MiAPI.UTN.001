using Api.Consummer;
using MiApp.UTN.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MiApp.MVC.Controllers
{
    public class EmpleadosController : Controller
    {
        // GET: EmpleadosController
        public ActionResult Index()
        {
            var empleado = Crud<Empleado>.ReadAll();
            return View(empleado);
        }

        // GET: EmpleadosController/Details/5
        public ActionResult Details(string id)
        {
            var datos = Crud<Empleado>.ReadById(id);
            return View(datos);
        }

        // GET: EmpleadosController/Create
        public ActionResult Create()
        {
            LeerListaDatos();

            return View();
        }

        private void LeerListaDatos()
        {
            var listaPersonas = Crud<Persona>.ReadAll();
            var listaCargos = Crud<Cargo>.ReadAll();

            ViewBag .selectlistPersonas = listaPersonas.Select(p =>
            new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = $"{p.Id} - {p.Apellido} {p.Nombre}"
            })
                .OrderBy(i => i.Text);

            ViewBag.selectlistCargos = listaCargos.Select(c =>
            new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            })
                .OrderBy(i => i.Text)
                .ToList();


        }

        // POST: EmpleadosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Empleado data)
        {
            try
            {
               Crud<Empleado>.Create(data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message;
                LeerListaDatos();
                return View(data);
            }
        }

        // GET: EmpleadosController/Edit/5
        public ActionResult Edit(int id)
        {
            var datos=Crud<Empleado>.ReadById(id.ToString());
            LeerListaDatos();
        
            return View(datos);
        }

        // POST: EmpleadosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id,Empleado datos)
        {
            try
            {
                Crud<Empleado>.Update(id, datos);
            
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message;
                return View(datos);
            }
        }

        // GET: EmpleadosController/Delete/5
        public ActionResult Delete(string id)
        {
            var datos = Crud<Empleado>.ReadById(id);
            LeerListaDatos();
            return View(datos);
        }

        // POST: EmpleadosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id,  Empleado datos)
        {
            try
            {
                Crud<Empleado>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex) 
            {
                ViewData["Message"]=ex.Message;
                return View(datos);
            }
        }
    }
}
