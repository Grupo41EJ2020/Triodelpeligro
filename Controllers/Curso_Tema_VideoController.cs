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
    public class Curso_Tema_VideoController : Controller
    {
        RepositorioCurso_Tema_Video repoCurso_Tema_Video = new RepositorioCurso_Tema_Video();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Curso_Tema_Video()
        {
            return View(repoCurso_Tema_Video.obtenerCurso_Tema_Videos());
        }

        public ActionResult Curso_Tema_VideoDetails(int id)
        {
            return View(repoCurso_Tema_Video.obtenerCurso_Tema_Video(id));
        }

        public ActionResult Curso_Tema_VideoDelete(int id)
        {
            return View(repoCurso_Tema_Video.obtenerCurso_Tema_Video(id));
        }

        [HttpPost]
        public ActionResult Curso_Tema_VideoDelete(int id, FormCollection frm)
        {
            repoCurso_Tema_Video.eliminarCurso_Tema_Video(id);
            return RedirectToAction("Curso_Tema_Video");
        }

        public ActionResult Curso_Tema_VideoEdit(int id)
        {
            return View(repoCurso_Tema_Video.obtenerCurso_Tema_Video(id));
        }

        [HttpPost]
        public ActionResult Curso_Tema_VideoEdit(int id, Curso_Tema_Video datos)
        {
            datos.IdCTV = id;
            repoCurso_Tema_Video.actualizarCurso_Tema_Video(datos);
            return RedirectToAction("Curso_Tema_Video");
        }

        public ActionResult Curso_Tema_VideoInsert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Curso_Tema_VideoInsert(Curso_Tema_Video datos)
        {
            repoCurso_Tema_Video.insertarCurso_Tema_Video(datos);
            return RedirectToAction("Curso_Tema_Video");
        }
    }
}
