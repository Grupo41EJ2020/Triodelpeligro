<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MVCLaboratorio.Models.Tema>>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>DatosTemas</title>
</head>
<body bgcolor="#ffccff">
    <table>
        <tr>
            <th></th>
            <th>
                <font color="black">IdTema</font>
            </th>
            <th>
                <font color="black">Nombre</font>
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Editar", "EditarTema", new { id=item.IdTema }) %>|
                <%: Html.ActionLink("Detalles", "DetallesTema", new { id=item.IdTema })%> |
                <%: Html.ActionLink("Borrar", "EliminarTemas", new { id=item.IdTema})%>
            </td>
            <td>
               <font color="black"> <%: item.IdTema %></font>
            </td>
            <td>
              <font color="black"><%: item.Nombre %></font>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Crear nuevo", "InsertarTemas") %>
        <br />
        <a href="/Opciones/Index">Regresar a otras Opciones</a>
    </p>

</body>
</html>

