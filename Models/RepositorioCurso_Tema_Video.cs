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
    public class RepositorioCurso_Tema_Video : ICurso_Tema_Video
    {
        public List<Curso_Tema_Video> obtenerCurso_Tema_Videos()
        {
            //obtener todos los Curso_Tema_Videos
            DataTable dtCurso_Tema_Videos = BaseHelper.ejecutarConsulta("SP_CURSO_TEMA_VIDEO_CONSULTAR_TODO", CommandType.StoredProcedure);

            List<Curso_Tema_Video> lstCurso_Tema_Videos = new List<Curso_Tema_Video>();

            //convertir el DataTable en List<Curso_Tema_Video> 

            foreach (DataRow item in dtCurso_Tema_Videos.Rows)
            {
                Curso_Tema_Video datosCurso_Tema_Video = new Curso_Tema_Video();

                datosCurso_Tema_Video.IdCTV = int.Parse(item["IdCTV"].ToString());
                datosCurso_Tema_Video.IdCT = int.Parse(item["IdCT"].ToString());
                datosCurso_Tema_Video.IdVideo = int.Parse(item["IdVideo"].ToString());

                lstCurso_Tema_Videos.Add(datosCurso_Tema_Video);

            }
            return lstCurso_Tema_Videos;
        }

        public Curso_Tema_Video obtenerCurso_Tema_Video(int idCurso_Tema_Video)
        {
            //consultar los datos del Curso_Tema_Video
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdCTV", idCurso_Tema_Video));

            DataTable dtCurso_Tema_Video = BaseHelper.ejecutarConsulta("SP_CURSO_TEMA_VIDEO_CONSULTAR_POR_ID", CommandType.StoredProcedure, parametros);

            Curso_Tema_Video miCurso_Tema_Video = new Curso_Tema_Video();

            if (dtCurso_Tema_Video.Rows.Count > 0)
            {
                miCurso_Tema_Video.IdCTV = int.Parse(dtCurso_Tema_Video.Rows[0]["IdCTV"].ToString());
                miCurso_Tema_Video.IdCT = int.Parse(dtCurso_Tema_Video.Rows[0]["IdCT"].ToString());
                miCurso_Tema_Video.IdVideo = int.Parse(dtCurso_Tema_Video.Rows[0]["IdVideo"].ToString());
                return miCurso_Tema_Video;
            }
            else
            {  //no encontrado 
                return null;
            }
        }

        public void insertarCurso_Tema_Video(Curso_Tema_Video datosCurso_Tema_Video)
        {
            //realizar el insert
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdCT", datosCurso_Tema_Video.IdCT));
            parametros.Add(new SqlParameter("@IdVideo", datosCurso_Tema_Video.IdVideo));

            BaseHelper.ejecutarConsulta("SP_CURSO_TEMA_VIDEO_INSERTAR", CommandType.StoredProcedure, parametros);
        }

        public void eliminarCurso_Tema_Video(int idCurso_Tema_Video)
        {
            //obtener info del Curso_Tema_Video
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdCTV", idCurso_Tema_Video));

            BaseHelper.ejecutarConsulta("SP_CURSO_TEMA_VIDEO_BORRAR", CommandType.StoredProcedure, parametros);
        }

        public void actualizarCurso_Tema_Video(Curso_Tema_Video datosCurso_Tema_Video)
        {
            //realizar el update
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@IdCTV", datosCurso_Tema_Video.IdCTV));
            parametros.Add(new SqlParameter("@IdCT", datosCurso_Tema_Video.IdCT));
            parametros.Add(new SqlParameter("@IdVideo", datosCurso_Tema_Video.IdVideo));

            BaseHelper.ejecutarConsulta("SP_CURSO_TEMA_VIDEO_EDITAR", CommandType.StoredProcedure, parametros);
        }

        public List<Curso_Tema_Video> obtenerCurso_Tema_Video()
        {
            DataTable dtCurso_Tema_Videos = BaseHelper.ejecutarConsulta("SP_CURSO_TEMA_VIDEO_CONSULTAR_TODO", CommandType.StoredProcedure);

            List<Curso_Tema_Video> lstCurso_Tema_Videos = new List<Curso_Tema_Video>();

            //convertir el DataTable en List<Curso_Tema_Video> 

            foreach (DataRow item in dtCurso_Tema_Videos.Rows)
            {
                Curso_Tema_Video datosCurso_Tema_Video = new Curso_Tema_Video();

                datosCurso_Tema_Video.IdCTV = int.Parse(item["IdCTV"].ToString());
                datosCurso_Tema_Video.IdCT = int.Parse(item["IdCT"].ToString());
                datosCurso_Tema_Video.IdVideo = int.Parse(item["IdVideo"].ToString());

                lstCurso_Tema_Videos.Add(datosCurso_Tema_Video);

            }
            return lstCurso_Tema_Videos;
        }
    }
}