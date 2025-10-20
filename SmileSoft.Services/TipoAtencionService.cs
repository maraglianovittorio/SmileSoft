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
    public class TipoAtencionService
    {
        public TipoAtencionDTO Add(TipoAtencionDTO dto)
        {
            var tipoAtencionRepository = new TipoAtencionRepository();

            // Validar que el tipo de atención no exista
            if (tipoAtencionRepository.TipoAtencionExists(dto.Descripcion))
            {
                throw new ArgumentException($"Ya existe un tipo de atención con la descripción '{dto.Descripcion}' y duración '{dto.Duracion}'  .");
            }

            TipoAtencion tipoAtencion = new TipoAtencion(0,dto.Descripcion, dto.Duracion);
            tipoAtencionRepository.Add(tipoAtencion);

            return dto;
        }

        public bool Delete(int id)
        {
            var tipoAtencionRepository = new TipoAtencionRepository();
            return tipoAtencionRepository.Delete(id);
        }

        public TipoAtencion GetTipoAtencion(int id)
        {
            var tipoAtencionRepository = new TipoAtencionRepository();
            TipoAtencion? tipoAtencion = tipoAtencionRepository.Get(id);
            if (tipoAtencion == null)
            {
                throw new Exception("No se encontró el tipo de atención.");
            }
            return new TipoAtencion(id: tipoAtencion.Id, descripcion: tipoAtencion.Descripcion, duracion: tipoAtencion.Duracion);
        }

        public IEnumerable<TipoAtencionDTO> GetAll()
        {
            var tipoAtencionRepository = new TipoAtencionRepository();
            var tipoAtenciones = tipoAtencionRepository.GetAll();
            return tipoAtenciones.Select(ta => new TipoAtencionDTO
            {
                Id = ta.Id,
                Descripcion = ta.Descripcion,
                Duracion = ta.Duracion
            }).ToList();
        }

        public bool Update(int id, TipoAtencionDTO dto)
        {
            var tipoAtencionRepository = new TipoAtencionRepository();

            if (tipoAtencionRepository.TipoAtencionExists(dto.Descripcion))
            {
                throw new ArgumentException($"Ya existe otro tipo de atención con la descripcion {dto.Descripcion}");
            }

            TipoAtencion tipoAtencion = new TipoAtencion(id, dto.Descripcion, dto.Duracion);
            return tipoAtencionRepository.Update(tipoAtencion);
        }
    }
}

