using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCLaboratorio.Models;
using MVCLaboratorio.Utilerias;
using System.Data;
using System.Data.SqlClient;

namespace MVCLaboratorio.Models
{
    public class RepositorioCursoTema : ICursoTema
    {
        public List<CursoTema> obtenerCursoTemas()
        {
            DataTable dtCursoTema = BaseHelper.ejecutarConsulta("sp_CursoTema_ConsultarTodo", CommandType.StoredProcedure);
            List<CursoTema> lstCursoTema = new List<CursoTema>();
            foreach (DataRow item in dtCursoTema.Rows)
            {
                CursoTema datosCursoTema = new CursoTema();
                datosCursoTema.IdCT = int.Parse(item["IdCT"].ToString());
                datosCursoTema.IdCurso = int.Parse(item["IdCurso"].ToString());
                datosCursoTema.IdTema = int.Parse(item["IdTema"].ToString());

                lstCursoTema.Add(datosCursoTema);
            }
            return lstCursoTema;
        }

        public CursoTema obtenerCursoTema(int idCursoTema)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdCT", idCursoTema));

            DataTable dtCursoTema = BaseHelper.ejecutarConsulta("sp_CursoTema_ConsultarPorID", CommandType.StoredProcedure, parametros);

            CursoTema miCursoTema = new CursoTema();

            if (dtCursoTema.Rows.Count > 0)
            {
                miCursoTema.IdCT = int.Parse(dtCursoTema.Rows[0]["IdTema"].ToString());
                miCursoTema.IdCurso = int.Parse(dtCursoTema.Rows[0]["IdCurso"].ToString());
                miCursoTema.IdTema = int.Parse(dtCursoTema.Rows[0]["IdTema"].ToString());

                return miCursoTema;
            }
            else
            {
                return null;
            }
        }

        public void insertarCursoTema(CursoTema datosCursoTema)
        {

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdCurso", datosCursoTema.IdCurso));
            parametros.Add(new SqlParameter("@IdTema", datosCursoTema.IdTema));

            BaseHelper.ejecutarConsulta("sp_CursoTema_Insertar", CommandType.StoredProcedure, parametros);
        }

        public void eliminarCursoTema(int idCursoTema)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdCT", idCursoTema));

            BaseHelper.ejecutarConsulta("sp_CursoTema_Eliminar", CommandType.StoredProcedure, parametros);
        }

        public void actualizarCursoTema(CursoTema datosCursoTema)
        {
             List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdCT", datosCursoTema.IdCT));
            parametros.Add(new SqlParameter("@IdCurso", datosCursoTema.IdCurso));
            parametros.Add(new SqlParameter("@IdTema", datosCursoTema.IdTema));

            BaseHelper.ejecutarConsulta("sp_CursoTema_Actualizar", CommandType.StoredProcedure, parametros);
        }
    }
}