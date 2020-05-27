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

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DatosTemas()
        {
            return View(repoTema.obtenerTemas());
        }
        public ActionResult DetallesTema(int id)
        {
            return View(repoTema.obtenerTema(id));
        }
        public ActionResult InsertarTemas(int id)
        {
            //NO FUNCIOOONAAAAA arreglar
            return View(repoTema.obtenerTema(id));
        }
        [HttpPost]
        public ActionResult InsertarTemas(int id, Tema datos)
        {

            //NO FUNCIOOONAAAAA arreglar
            datos.IdTema = id;
            repoTema.insertarTema(datos);
            return RedirectToAction("DatosTemas");
        }
        public ActionResult EliminarTema(int id)
        {

            return View(repoTema.obtenerTema(id));
        }

    }
}
