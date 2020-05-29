<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MVCLaboratorio.Models.Empleado>>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>DatosEmpleados</title>
</head>
<body bgcolor="#ffccff">
    <table>
        <tr>
            <th></th>
            <th>
                IdEmpleado
            </th>
            <th>
                Nombre
            </th>
            <th>
                Direccion
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Editar", "EditEmpleado", new {  id=item.IdEmpleado }) %> |
                <%: Html.ActionLink("Detalles", "DetailsEmpleado", new { id = item.IdEmpleado })%> |
                <%: Html.ActionLink("Eliminar", "DeleteEmpleado", new { id = item.IdEmpleado })%>
            </td>
            <td>
                <%: item.IdEmpleado %>
            </td>
            <td>
                <%: item.Nombre %>
            </td>
            <td>
                <%: item.Direccion %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("AgregarEmpleado", "CreateEmpleado") %>
        <br />  
        <a href="/Opciones/Index">Regresar a otras Opciones</a>
    </p>

</body>
</html>

