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
    public class CursoController : Controller
    {
        //
        // GET: /Curso/

        RepositorioCursos repoCurso = new RepositorioCursos();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DatosCursos()
        {
            return View(repoCurso.obtenerCursos());
        }

        public ActionResult DetailsCurso(int id)
        {
            return View(repoCurso.obtenerCurso(id));
        }

        public ActionResult DeleteCurso(int id)
        {
            return View(repoCurso.obtenerCurso(id));
         }

        [HttpPost]
        public ActionResult DeleteCurso(int id, FormCollection frm)
        {
            repoCurso.eliminarCurso(id);
            return RedirectToAction("DatosCursos");
            }

        public ActionResult EditCurso(int id)
        {
            return View(repoCurso.obtenerCurso(id));
        }

        [HttpPost]
        public ActionResult EditCurso(int id, Curso datos)
        {
            datos.IdCurso = id;
            repoCurso.actualizarCurso(datos);
            return RedirectToAction("DatosCursos");
        }

        public ActionResult CreateCurso()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult CreateCurso(Curso datosCurso)
        {
            repoCurso.insertarCurso(datosCurso);
            return RedirectToAction("DatosCursos");
        }

    }

    }

