using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using MVCLaboratorio.Utilerias;
using MVCLaboratorio.Models;

namespace MVCLaboratorio.Controllers
{
    public class EmpleadoController : Controller
    {
        RepositorioEmpleados repoEmpleado = new RepositorioEmpleados();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DatosEmpleados()
        {
            return View(repoEmpleado.obtenerEmpleados());
        }

        public ActionResult DetailsEmpleado(int id)
        {
            return View(repoEmpleado.obtenerEmpleado(id));
        }

        public ActionResult DeleteEmpleado(int id)
        {
            return View(repoEmpleado.obtenerEmpleado(id));
         }

        [HttpPost]
        public ActionResult DeleteEmpleado(int id, FormCollection frm)
        {
            repoEmpleado.eliminarEmpleado(id);
            return RedirectToAction("DatosEmpleados");
            }

        public ActionResult EditEmpleado(int id)
        {
            return View(repoEmpleado.obtenerEmpleado(id));
        }

        [HttpPost]
        public ActionResult EditEmpleado(int id, Empleado datos)
        {
            datos.IdEmpleado = id;
            repoEmpleado.actualizarEmpleado(datos);
            return RedirectToAction("DatosEmpleados");
        }

        public ActionResult CreateEmpleado()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult CreateEmpleado(Empleado datosEmpleado)
        {
            repoEmpleado.insertarEmpleado(datosEmpleado);
            return RedirectToAction("DatosEmpleados");
        }

    }
}
