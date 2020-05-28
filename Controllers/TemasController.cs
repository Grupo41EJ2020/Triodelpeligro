using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using MVCLaboratorio.Models;
using MVCLaboratorio.Utilerias;

namespace MVCLaboratorio.Controllers
{
    public class TemasController : Controller
    {

        RepositorioTemas repoTema = new RepositorioTemas();

        public ActionResult DatosTemas()
        {
            return View(repoTema.obtenerTemas());
        }
        public ActionResult DetallesTema(int id)
        {
            return View(repoTema.obtenerTema(id));
        }
        public ActionResult InsertarTemas()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InsertarTemas(Tema datos)
        {
            repoTema.insertarTema(datos);
            return RedirectToAction("DatosTemas");
        }
        public ActionResult EliminarTemas(int id)
        {
            return View(repoTema.obtenerTema(id));
        }
        [HttpPost]
        public ActionResult EliminarTemas(int id, FormCollection frm)
        {
            repoTema.eliminarTema(id);
            return RedirectToAction("DatosTemas");
        }
        public ActionResult EditarTema(int id)
        {
            return View(repoTema.obtenerTema(id));
        }
        [HttpPost]
        public ActionResult EditarTema(int id, Tema datos)
        {
            datos.IdTema = id;
            repoTema.actualizarTema(datos);
            return RedirectToAction("DatosTemas");
        }

    }
}
