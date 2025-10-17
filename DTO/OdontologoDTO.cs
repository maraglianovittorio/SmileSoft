using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmileSoft.Dominio;

namespace DTO
{
    public class OdontologoDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [StringLength(100, ErrorMessage = "El apellido no puede exceder 100 caracteres")]
        public string Apellido { get; set; } = string.Empty;

        [Required(ErrorMessage = "El numero de matricula es obligatorio")]
        [StringLength(20, ErrorMessage = "El numero de  matricula no puede exceder 20 caracteres")]
        public string NroMatricula { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "El formato del email no es válido")]
        [StringLength(100, ErrorMessage = "El email no puede exceder 100 caracteres")]
        public string Email { get; set; } = string.Empty;
        //[StringLength(50, ErrorMessage = "El username no puede exceder 50 caracteres")]
        //public string Username { get; set; } = string.Empty;
        //[StringLength(20, ErrorMessage = "El password no puede exceder 20 caracteres")]
        //public string Password { get; set; } = string.Empty;
        //public List<ObraSocial> ObrasSociales { get; set; } = new List<ObraSocial>();
    }
}
