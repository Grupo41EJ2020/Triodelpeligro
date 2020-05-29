<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MVCLaboratorio.Models.CursoTema>>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Index</title>
</head>
<body bgcolor="#ffccff">
    <table>
        <tr>
            <th></th>
            <th>
                IdCT
            </th>
            <th>
                IdCurso
            </th>
            <th>
                IdTema
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Editar", "ActualizarCursoTema", new {  id=item.IdCT  }) %> |
                <%: Html.ActionLink("Detalles", "DetallesCursoTema", new {  id=item.IdCT  })%> |
                <%: Html.ActionLink("Borrar", "EliminarCursoTema", new {  id=item.IdCT  })%>
            </td>
            <td>
                <%: item.IdCT %>
            </td>
            <td>
                <%: item.IdCurso %>
            </td>
            <td>
                <%: item.IdTema %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Insertar datos nuevo", "InsertarCursoTema") %>
        <br />
        <a href="/Opciones/Index">Regresar a otras Opciones</a>
    </p>

</body>
</html>

