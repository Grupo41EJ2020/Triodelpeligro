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

    public class RepositorioTemas : ITema
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

            DataTable dtTema = BaseHelper.ejecutarConsulta("sp_Tema_ConsultarPorID", CommandType.StoredProcedure, parametros);

            Tema miTema = new Tema();

            if (dtTema.Rows.Count > 0)
            {
                miTema.IdTema = int.Parse(dtTema.Rows[0]["IdTema"].ToString());
                miTema.Nombre = dtTema.Rows[0]["Nombre"].ToString();

                return miTema;
            }
            else
            {  
                return null;
            }
        }

        public void insertarTema(Tema datosTema)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@Nombre", datosTema.Nombre));

            BaseHelper.ejecutarConsulta("sp_Tema_Insertar", CommandType.StoredProcedure, parametros);
        }

        public void eliminarTema(int idTema)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdTema", idTema));

            BaseHelper.ejecutarConsulta("sp_Tema_Eliminar", CommandType.StoredProcedure, parametros);
        }

        public void actualizarTema(Tema datosTema)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdTema", datosTema.IdTema));
            parametros.Add(new SqlParameter("@Nombre", datosTema.Nombre));

            BaseHelper.ejecutarConsulta("sp_Tema_Actualizar", CommandType.StoredProcedure, parametros);
        }
    }
}