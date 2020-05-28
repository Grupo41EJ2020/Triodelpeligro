using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCLaboratorio.Models;
using System.Data;
using System.Data.SqlClient;
using MVCLaboratorio.Utilerias;

namespace MVCLaboratorio.Models
{
    public class RepositorioCursos : ICurso
    {
        public List<Curso> obtenerCursos()
        {
            //Obtener todos los cursos
            DataTable dtCursos = BaseHelper.ejecutarConsulta("sp_Curso_ConsultarTodo", CommandType.StoredProcedure);
            List<Curso> lstcursos = new List<Curso>();

            foreach (DataRow item in dtCursos.Rows)
            {
                Curso datosCurso = new Curso();

                datosCurso.IdCurso = int.Parse(item["IdCurso"].ToString());
                datosCurso.Descripcion = item["Descripcion"].ToString();
                datosCurso.IdEmpleado = int.Parse(item["IdEmpleado"].ToString());
                lstcursos.Add(datosCurso);
            }
            return lstcursos;
        }

        public Curso obtenerCurso(int idCurso)
        {
            //Obtener Curso
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdCurso", idCurso));
            DataTable dtCurso = BaseHelper.ejecutarConsulta("sp_Curso_ConsultarPorID", CommandType.StoredProcedure, parametros);
            Curso miCurso = new Curso();
            if (dtCurso.Rows.Count > 0)
            {
                miCurso.IdCurso = int.Parse(dtCurso.Rows[0]["IdCurso"].ToString());
                miCurso.Descripcion = dtCurso.Rows[0]["Descripcion"].ToString();
                miCurso.IdEmpleado = int.Parse(dtCurso.Rows[0]["IdEmpleado"].ToString());
                return miCurso;
            }
            else
            {
                return null;
            }
        }

        public void insertarCurso(Curso datosCurso)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@Descripcion", datosCurso.Descripcion));
            parametros.Add(new SqlParameter("@IdEmpleado", datosCurso.IdEmpleado));
            BaseHelper.ejecutarConsulta("sp_Curso_Insertar", CommandType.StoredProcedure, parametros);
        }

        public void eliminarCurso(int idCurso)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdCurso", idCurso));
            BaseHelper.ejecutarConsulta("sp_Curso_Eliminar", CommandType.StoredProcedure, parametros);
        }

        public void actualizarCurso(Curso datosCurso)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdCurso", datosCurso.IdCurso));
            parametros.Add(new SqlParameter("@Descripcion", datosCurso.Descripcion));
            parametros.Add(new SqlParameter("@IdEmpleado", datosCurso.IdEmpleado));
            BaseHelper.ejecutarConsulta("sp_Curso_Actualizar", CommandType.StoredProcedure, parametros);
        }
    }
}