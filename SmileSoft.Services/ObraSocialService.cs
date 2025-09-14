using DTO;
using SmileSoft.Data;
using SmileSoft.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileSoft.Services
{
    public class ObraSocialService
    {
        public ObraSocialDTO Add(ObraSocialDTO dto)
        {
            var obraSocialRepository = new ObraSocialRepository();
            ObraSocial obraSocial = new ObraSocial(0, dto.Nombre);
            // Validar que la obra social no exista
            if (obraSocialRepository.OSExists(dto.Nombre))
            {
                throw new ArgumentException($"Ya existe una obra social con el nombre '{dto.Nombre}'.");
            }

            obraSocialRepository.Add(obraSocial);

            return dto;
        }
        public bool Delete(int id)
        {
            var obraSocialRepository = new ObraSocialRepository();
            return obraSocialRepository.Delete(id);
        }
        public ObraSocialDTO GetObraSocial(int id)
        {
            var obraSocialRepository = new ObraSocialRepository();
            ObraSocial? obraSocial = obraSocialRepository.Get(id);
            if (obraSocial == null)
            {
                throw new Exception("No se encontró la obra social.");
            }
            return new ObraSocialDTO
            {
                Nombre = obraSocial.Nombre,
            };
        }
        public IEnumerable<ObraSocialDTO> GetAll()
        {
            var obraSocialRepository = new ObraSocialRepository();
            var obrasSociales = obraSocialRepository.GetAll();
            return obrasSociales.Select(o => new ObraSocialDTO
            {

                Id = o.Id,
                Nombre = o.Nombre
            }).ToList();
        }
        public bool Update(int id, ObraSocialDTO dto)
        {
            var obraSocialRepository = new ObraSocialRepository();
            // Validar que la obra social no exista en otro paciente
            if (obraSocialRepository.OSExists(dto.Nombre, id))
            {
                throw new ArgumentException($"Ya existe otra obra social con el nombre '{dto.Nombre},' ',{dto.Id}'.");
            }

            ObraSocial obraSocial = new ObraSocial(id, dto.Nombre);
            return obraSocialRepository.Update(obraSocial);

        }
    }
}

