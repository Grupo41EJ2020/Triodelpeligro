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
        //
        // GET: /Empleado/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DatosEmpleados()
        {
            //Obtener todos los empleados
            DataTable dtEmpleados = BaseHelper.ejecutarConsulta("sp_Empleado_ConsultarTodo", CommandType.StoredProcedure);
            List<Empleado> lstempleados = new List<Empleado>();

            foreach (DataRow item in dtEmpleados.Rows)
            {
                Empleado datosEmpleado = new Empleado();

                datosEmpleado.IdEmpleado = int.Parse(item["IdEmpleado"].ToString());
                datosEmpleado.Nombre = item["Nombre"].ToString();
                datosEmpleado.Direccion = item["Direccion"].ToString();
                lstempleados.Add(datosEmpleado);
            }
            return View(lstempleados);
        }
    }
}
