using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLaboratorio.Models;
using MVCLaboratorio.Utilerias;
using System.Data;
using System.Data.SqlClient;

namespace MVCLaboratorio.Controllers
{
    public class TemasController : Controller
    {
        RepositorioTema repoTema = new RepositorioTema();

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
