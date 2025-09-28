using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TipoAtencionDTO
    {
        public int Id { get; set; }
       
        [Required(ErrorMessage = "La descripcion es obligatoria")]
        [StringLength(100, ErrorMessage = "La descripcion no puede exceder 100 caracteres")]
        public string Descripcion { get; set; } = string.Empty;
        [Required(ErrorMessage = "La duracion es obligatoria")]
        //[StringLength(100, ErrorMessage = "La descripcion no puede exceder 100 caracteres")]
        public TimeSpan Duracion { get; set; }



    }
}
