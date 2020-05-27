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
    public class RepositorioTema : ITema
    {

        public List<Tema> obtenerTemas()
        {
            DataTable dtTemas = BaseHelper.ejecutarConsulta("sp_Tema_ConsultarTodo", CommandType.StoredProcedure);
            List<Tema> lstTemas = new List<Tema>();
            foreach (DataRow item in dtTemas.Rows)
            {
                Tema datosTema = new Tema();
                datosTema.IdTema = int.Parse(item["IdTema"].ToString());
                datosTema.Nombre = item["Nombre"].ToString();

                lstTemas.Add(datosTema);
            }
            return lstTemas;
        }

        public Tema obtenerTema(int idTema)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdTema", idTema));
            DataTable dtTemas = BaseHelper.ejecutarConsulta("sp_Tema_ConsultarPorID", CommandType.StoredProcedure);

            Tema MiTema = new Tema();

            if (dtTemas.Rows.Count > 0)
            {
                MiTema.IdTema = int.Parse(dtTemas.Rows[0]["IdTema"].ToString());
                MiTema.Nombre = dtTemas.Rows[0]["Nombre"].ToString();
                return MiTema;
            }
            else
            {
                return null;
            }
        }
        public void eliminarTema(int idTema)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdVideo", idTema));

            BaseHelper.ejecutarConsulta("sp_Tema_Eliminar", CommandType.StoredProcedure, parametros);
        }

        public void actualizarTema(Tema datosTema)
        {
            //realizar el update
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdVideo", datosTema.IdTema));
            parametros.Add(new SqlParameter("@Nombre", datosTema.Nombre));

            BaseHelper.ejecutarConsulta("sp_Tema_Actualizar", CommandType.StoredProcedure, parametros);
        }

        public void insertarTema(Tema datosTema)
        {
            //No funciona ARREGLAR
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdVideo", datosTema.IdTema));
            parametros.Add(new SqlParameter("@Nombre", datosTema.Nombre));

            BaseHelper.ejecutarConsulta("SP_TEMA_INSERTAR", CommandType.StoredProcedure, parametros);
        }
    }
}