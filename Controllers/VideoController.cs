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
    public class VideoController : Controller
    {
        //
        // GET: /Video/

        RepositorioVideo repoVideo = new RepositorioVideo();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Quique07DsConsultarTodo()
        {
            return View(repoVideo.obtenerVideos());
        }

        public ActionResult Quique07DsDetails(int id)
        {
            return View(repoVideo.obtenerVideo(id));
        }

        public ActionResult Quique07DsDelete(int id)
        {
            return View(repoVideo.obtenerVideo(id));
        }

        [HttpPost]
        public ActionResult Quique07DsDelete(int id, FormCollection frm)
        {
            repoVideo.eliminarVideo(id);
            return RedirectToAction("Quique07Ds");
        }

        public ActionResult Quique07DsEdit(int id)
        {
            return View(repoVideo.obtenerVideo(id));
        }

        [HttpPost]
        public ActionResult Quique07DsEdit(int id, Video datos)
        {
            datos.IdVideo = id;
            repoVideo.actualizarVideo(datos);
            return RedirectToAction("Quique07Ds");
        }

        public ActionResult Quique07DsInsert(int id)
        {
            return View(repoVideo.obtenerVideo(id));
        }

        [HttpPost]
        public ActionResult Quique07DsInsert(int id, Video datos)
        {
            datos.IdVideo = id;
            repoVideo.insertarVideo(datos);
            return RedirectToAction("Quique07Ds");
        }
    }
}
