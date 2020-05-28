using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLaboratorio.Models
{
    public interface ICursoTema
    {
        List<CursoTema> obtenerCursoTemas();
        CursoTema obtenerCursoTema(int idCursoTema);
        void insertarCursoTema(CursoTema datosCursoTema);
        void eliminarCursoTema(int idCursoTema);
        void actualizarCursoTema(CursoTema datosCursoTema);
    }
}