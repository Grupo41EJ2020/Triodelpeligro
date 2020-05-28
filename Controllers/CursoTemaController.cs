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
    public class CursoTemaController : Controller
    {
        RepositorioCursoTema repoCursoTema = new RepositorioCursoTema();

        public ActionResult Index()
        {
            return View(repoCursoTema.obtenerCursoTemas());
        }
        public ActionResult DetallesCursoTema(int id)
        {
            return View(repoCursoTema.obtenerCursoTema(id));
        }
        public ActionResult InsertarCursoTema()
        {
            return View();
        }
        [HttpPost]
        public ActionResult insertarCursoTema(CursoTema datos)
        {
            repoCursoTema.insertarCursoTema(datos);
            return RedirectToAction("Index");
        }
        public ActionResult EliminarCursoTema(int id)
        {
            return View(repoCursoTema.obtenerCursoTema(id));
        }
        [HttpPost]
        public ActionResult EliminarCursoTema(int id, FormCollection frm)
        {
            repoCursoTema.eliminarCursoTema(id);
            return RedirectToAction("Index");
        }
        public ActionResult ActualizarCursoTema(int id)
        {
            return View(repoCursoTema.obtenerCursoTema(id));
        }
        [HttpPost]
        public ActionResult ActualizarCursoTema(int id, CursoTema datos)
        {
            datos.IdCT = id;
            repoCursoTema.actualizarCursoTema(datos);
            return RedirectToAction("Index");
        }
    }
}
