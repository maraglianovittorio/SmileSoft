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
    public class OdontologoService
    {
        public OdontologoDTO Add(OdontologoDTO dto)
        {
            var odontologoRepository = new OdontologoRepository();
            Odontologo odontologo = new Odontologo(0, dto.Nombre,dto.Apellido,dto.NroDni,dto.FechaNacimiento,dto.Direccion,dto.Email,dto.Telefono,dto.NroMatricula);
            // Validar que el odontólogo no exista
            if (odontologoRepository.NroMatriculaExists(dto.NroMatricula))
            {
                throw new ArgumentException($"Ya existe un odontólogo con el nombre '{dto.Nombre}'.");
            }

            odontologoRepository.Add(odontologo);

            return dto;
        }
        public bool Delete(int id)
        {
            var odontologoRepository = new OdontologoRepository();
            return odontologoRepository.Delete(id);
        }
        public OdontologoDTO GetOdontologo(int id)
        {
            var odontologoRepository = new OdontologoRepository();
            Odontologo? odontologo = odontologoRepository.Get(id);
            if (odontologo == null)
            {
                throw new Exception("No se encontró el odontólogo.");
            }
            return new OdontologoDTO
            {
                Nombre = odontologo.Nombre,
                NroMatricula = odontologo.NroMatricula,
                Apellido = odontologo.Apellido,
                Email = odontologo.Email,
            };
        }
        public IEnumerable<OdontologoDTO> GetAll()
        {
            var odontologoRepository = new OdontologoRepository();
            var odontologos = odontologoRepository.GetAll();
            return odontologos.Select(o => new OdontologoDTO
            {

                Id = o.Id,
                Nombre = o.Nombre,
                Apellido = o.Apellido,
                NroMatricula = o.NroMatricula,
                Email = o.Email

            }).ToList();
        }
        public bool Update(int id, OdontologoDTO dto)
        {
            var odontologoRepository = new OdontologoRepository();
            // Validar que el nombre del odontólogo no exista
            if (odontologoRepository.NroMatriculaExists(dto.NroMatricula, id))
            {
                throw new ArgumentException($"Ya existe otro odontólogo con el nombre '{dto.Nombre},' ',{dto.Id}'.");
            }

            Odontologo odontologo = new Odontologo(0, dto.Nombre, dto.Apellido, dto.NroDni, dto.FechaNacimiento, dto.Direccion, dto.Email, dto.Telefono, dto.NroMatricula);
            return odontologoRepository.Update(odontologo);

        }
    }
}

