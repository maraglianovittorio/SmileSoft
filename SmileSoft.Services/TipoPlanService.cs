using SmileSoft.DTO;
using SmileSoft.Data;
using SmileSoft.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileSoft.Services
{
    public class TipoPlanService
    {
        public TipoPlanDTO Add(TipoPlanDTO dto)
        {
            var tipoPlanRepository = new TipoPlanRepository();
            
            // Validar que el tipo de plan no exista
            if (tipoPlanRepository.TipoPlanExists(dto.Nombre, dto.ObraSocialId))
            {
                throw new ArgumentException($"Ya existe un tipo de plan con el nombre '{dto.Nombre}' para esta obra social.");
            }

            TipoPlan tipoPlan = new TipoPlan(0,dto.Nombre,dto.Descripcion,dto.ObraSocialId);
            tipoPlanRepository.Add(tipoPlan);

            return dto;
        }

        public bool Delete(int id)
        {
            var tipoPlanRepository = new TipoPlanRepository();
            return tipoPlanRepository.Delete(id);
        }

        public TipoPlan GetTipoPlan(int id)
        {
            var tipoPlanRepository = new TipoPlanRepository();
            TipoPlan? tipoPlan = tipoPlanRepository.Get(id);
            if (tipoPlan == null)
            {
                throw new Exception("No se encontró el tipo de plan.");
            }
            return new TipoPlan(id: tipoPlan.Id, nombre: tipoPlan.Nombre, descripcion: tipoPlan.Descripcion, obraSocialId: tipoPlan.ObraSocialId);
        }

        public IEnumerable<TipoPlanDTO> GetAll()
        {
            var tipoPlanRepository = new TipoPlanRepository();
            var tipoPlanes = tipoPlanRepository.GetAll();
            return tipoPlanes.Select(tp => new TipoPlanDTO
            {
                Id = tp.Id,
                Nombre = tp.Nombre,
                Descripcion = tp.Descripcion,
                ObraSocialId = tp.ObraSocialId
            }).ToList();
        }
        public IEnumerable<TipoPlanDTO> GetByObraSocialId(int obraSocialId)
        {
            var tipoPlanRepository = new TipoPlanRepository();
            var tipoPlanes = tipoPlanRepository.GetByObraSocialId(obraSocialId);
            return tipoPlanes.Select(tp => new TipoPlanDTO
            {
                Id = tp.Id,
                Nombre = tp.Nombre,
                Descripcion = tp.Descripcion,
                ObraSocialId = tp.ObraSocialId
            }).ToList();
        }
        public bool Update(int id, TipoPlanDTO dto)
        {
            var tipoPlanRepository = new TipoPlanRepository();
            
            // Validar que el tipo de plan no exista en la misma obra social
            if (tipoPlanRepository.TipoPlanExists(dto.Nombre, dto.ObraSocialId, id))
            {
                throw new ArgumentException($"Ya existe otro tipo de plan con el nombre '{dto.Nombre}' en esta obra social.");
            }

            TipoPlan tipoPlan = new TipoPlan(id, dto.Nombre, dto.Descripcion, dto.ObraSocialId);
            return tipoPlanRepository.Update(tipoPlan);
        }
    }
}

