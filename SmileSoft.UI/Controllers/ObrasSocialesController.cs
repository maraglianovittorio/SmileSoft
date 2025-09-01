using Microsoft.AspNetCore.Mvc;
using SmileSoft.Dominio;
using DTO;

namespace SmileSoft.UI.Controllers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ObrasSocialesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<ObraSocial>> GetObrasSociales()
        {
            return Ok(ObraSocial.ListaOS);
        }

        [HttpGet("{id}")]
        public ActionResult<ObraSocial> GetObraSocial(int id)
        {
            var obraSocial = ObraSocial.ListaOS.FirstOrDefault(o => o.Id == id);
            if (obraSocial == null)
            {
                return NotFound();
            }
            return Ok(obraSocial);
        }

        [HttpPost]
        public ActionResult<ObraSocial> CreateObraSocial(ObraSocialDTO obraSocialDTO)
        {
            // Validación de campos obligatorios
            var errores = new List<string>();

            if (string.IsNullOrWhiteSpace(obraSocialDTO.Nombre))
                errores.Add("El nombre es obligatorio");

            if (errores.Count > 0)
            {
                return BadRequest(new
                {
                    error = "Datos inválidos",
                    message = "Faltan campos obligatorios",
                    details = errores
                });
            }

            var nuevoID = ObraSocial.ObtenerProximoID();
            var buscaNombre = ObraSocial.ListaOS.FirstOrDefault(o => o.Nombre == obraSocialDTO.Nombre);
            if (buscaNombre != null)
            {
                return Conflict(new
                {
                    error = "Nombre de obra social duplicado",
                    message = $"Ya existe una obra social con el nombre {obraSocialDTO.Nombre}",
                    field = "Nombre"
                });
            }

            // Crear la obra social con datos limpios (trim)
            var nuevaObraSocial = new ObraSocial(
                nuevoID,
                obraSocialDTO.Nombre.Trim()
            );

            ObraSocial.ListaOS.Add(nuevaObraSocial);
            return CreatedAtAction(nameof(GetObraSocial), new { id = nuevoID }, nuevaObraSocial);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateObraSocial(int id, ObraSocialDTO obraSocialDTO)
        {
            var obraSocial = ObraSocial.ListaOS.FirstOrDefault(p => p.Id == id);
            if (obraSocial == null)
            {
                return NotFound();
            }

            var buscaNombre = ObraSocial.ListaOS.FirstOrDefault(p => p.Nombre == obraSocialDTO.Nombre && p.Id != id);
            if (buscaNombre != null)
            {
                return Conflict(new
                {
                    error = "Nombre de obra social duplicado",
                    message = $"Ya existe una obra social con el nombre {obraSocialDTO.Nombre}",
                    field = "Nombre"
                });
            }

            obraSocial.Nombre = obraSocialDTO.Nombre;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteObraSocial(int id)
        {
            var obraSocial = ObraSocial.ListaOS.FirstOrDefault(p => p.Id == id);
            if (obraSocial == null)
            {
                return NotFound();
            }

            ObraSocial.ListaOS.Remove(obraSocial);
            return NoContent();
        }
    }
}