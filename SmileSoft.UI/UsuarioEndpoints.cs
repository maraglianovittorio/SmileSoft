using DTO;
using SmileSoft.Services;

namespace SmileSoft.WebAPI
{
    public static class UsuarioEndpoints
    {
        public static void MapUsuarioEndpoints(this WebApplication app)
        {
            app.MapGet("/usuarios", () =>
            {
                UsuarioService usuarioService = new UsuarioService();
                var dtos = usuarioService.GetAll();
                return Results.Ok(dtos);
            }).WithName("GetUsuarios")
            .Produces<List<UsuarioDTO>>(StatusCodes.Status200OK);
            app.MapGet($"usuarios/id", (int id) =>
            {
                UsuarioService usuarioService = new UsuarioService();
                UsuarioDTO dto = usuarioService.GetUsuario(id);
                return dto is not null ? Results.Ok(dto) : Results.NotFound();
            }).WithName("Get Usuario");
            app.MapPost("/usuarios", (UsuarioCreateDTO usuarioDTO) =>
            {
                try
                {
                    UsuarioService usuarioService = new UsuarioService();
                    // Validación de campos obligatorios
                    var errores = new List<string>();
                    if (string.IsNullOrWhiteSpace(usuarioDTO.Username))
                        errores.Add("El username es obligatorio");
                    if (string.IsNullOrWhiteSpace(usuarioDTO.Password))
                        errores.Add("El password es obligatorio");
                    if (string.IsNullOrWhiteSpace(usuarioDTO.Rol))
                        errores.Add("El rol es obligatorio");
                    if (errores.Count > 0)
                    {
                        return Results.BadRequest(new
                        {
                            error = "Datos inválidos",
                            message = "Faltan campos obligatorios",
                            details = errores
                        });
                    }
                    var dto = usuarioService.Add(usuarioDTO);
                    return Results.Created($"/usuarios/{dto.Id}", dto);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new
                    {
                        error = "No se pudo crear el usuario",
                        message = ex.Message
                    });
                }

            }).WithName("CreateUsuario");
            app.MapPut("/usuarios/{id}", (int id, UsuarioUpdateDTO usuario) =>
            {
                try
                {
                    UsuarioService usuarioService = new UsuarioService();
                    var found = usuarioService.GetUsuario(id);
                    if (found == null)
                    {
                        return Results.NotFound(new { error = "No se encontró el usuario." });
                    }
                    usuarioService.Update(id, usuario);

                    return Results.NoContent();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("UpdateUsuario");
            app.MapDelete("/usuarios/{id}", (int id) =>
            {
                UsuarioService usuarioService = new UsuarioService();
                var eliminado = usuarioService.Delete(id);
                return eliminado ? Results.NoContent() : Results.NotFound();
            }).WithName("DeleteUsuario");
            app.MapGet("/usuarios/{username}", (string username) =>
            {
                UsuarioService usuarioService = new UsuarioService();
                var usuario = usuarioService.GetByUsername(username);
                return usuario is not null ? Results.Ok(usuario) : Results.NotFound();
            }).WithName("GetUsuarioByUsername");
        }
    }
}
