<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<MVCLaboratorio.Models.CursoTema>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>EliminarCursoTema</title>
</head>
<body>
    <h3>¿Esta seguro de querer Borrar esta informacion? una vez que de Borrar se Eliminara permanentemente</h3>
    <fieldset>
        <legend>Datos</legend>
        
        <div class="display-label">IdCT</div>
        <div class="display-field"><%: Model.IdCT %></div>
        
        <div class="display-label">IdCurso</div>
        <div class="display-field"><%: Model.IdCurso %></div>
        
        <div class="display-label">IdTema</div>
        <div class="display-field"><%: Model.IdTema %></div>
        
    </fieldset>
    <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Borrar" /> |
		    <%: Html.ActionLink("Regresar a la lista", "Index") %>
        </p>
    <% } %>

</body>
</html>

