<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MVCLaboratorio.Models.Curso_Tema_Video>>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Curso_Tema_Video</title>
</head>
<body bgcolor="#ffccff">
    <table>
        <tr>
            <th></th>
            <th>
                IdCTV
            </th>
            <th>
                IdCT
            </th>
            <th>
                IdVideo
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "Curso_Tema_VideoEdit", new {  id=item.IdCTV  }) %> |
                <%: Html.ActionLink("Details", "Curso_Tema_VideoDetails", new {  id=item.IdCTV  })%> |
                <%: Html.ActionLink("Delete", "Curso_Tema_VideoDelete", new {  id=item.IdCTV })%>
            </td>
            <td>
                <%: item.IdCTV %>
            </td>
            <td>
                <%: item.IdCT %>
            </td>
            <td>
                <%: item.IdVideo %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Crear Nuevo Curso Tema Video", "Curso_Tema_VideoInsert") %>
        <br />  
        <a href="/Opciones/Index">Regresar a otras Opciones</a>
    </p>

</body>
</html>

