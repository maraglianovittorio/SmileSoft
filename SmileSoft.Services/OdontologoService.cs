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
        public OdontologoCreacionDTO Add(OdontologoCreacionDTO dto)
        {
            var odontologoRepository = new OdontologoRepository();
            var usuarioRepository = new UsuarioRepository();
            var personaRepository = new PersonaRepository();
            if (usuarioRepository.UsernameExists(dto.Username))
            {
                throw new ArgumentException($"Ya existe un usuario con el nombre de usuario '{dto.Username}'.");
            }
            var nuevoUsuario = new Usuario(dto.Username, dto.Password, "Odontologo");
            Odontologo odontologo = new Odontologo(0,dto.Nombre,dto.Apellido,dto.NroDni,dto.FechaNacimiento,dto.Direccion,dto.Email,dto.Telefono,dto.NroMatricula,nuevoUsuario);
            // Validar que el odontólogo no exista
            if (odontologoRepository.NroMatriculaExists(dto.NroMatricula))
            {
                throw new ArgumentException($"Ya existe un odontólogo con el nombre '{dto.Nombre}'.");
            }
            if (personaRepository.DNIExists(dto.NroDni))
            {
                throw new ArgumentException($"Ya existe una persona con el DNI '{dto.NroDni}'.");
            }

            odontologoRepository.Add(odontologo);

            return dto;
        }
        public bool Delete(int id)
        {
            var odontologoRepository = new OdontologoRepository();
            var usuarioRepository = new UsuarioRepository();
            // borro tambien el usuario asociado
            var odontologo = odontologoRepository.Get(id);
            if (odontologo != null)
            {
                usuarioRepository.Delete(odontologo.UsuarioId);
            }
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
                Id = odontologo.Id,
                Nombre = odontologo.Nombre,
                NroMatricula = odontologo.NroMatricula,
                Apellido = odontologo.Apellido,
                Email = odontologo.Email,
                Direccion = odontologo.Direccion,
                Telefono = odontologo.Telefono,
                NroDni = odontologo.NroDni, 
                FechaNacimiento = odontologo.FechaNacimiento,
            };
        }
        public IEnumerable<OdontologoDTO> GetAll()
        {
            var odontologoRepository = new OdontologoRepository();
            var odontologos = odontologoRepository.GetAll();
            return odontologos.Select(odontologo => new OdontologoDTO
            {

                Id = odontologo.Id,
                Nombre = odontologo.Nombre,
                NroMatricula = odontologo.NroMatricula,
                Apellido = odontologo.Apellido,
                Email = odontologo.Email,
                Direccion = odontologo.Direccion,
                Telefono = odontologo.Telefono,
                NroDni = odontologo.NroDni,
                FechaNacimiento = odontologo.FechaNacimiento,


            }).ToList();
        }
        public bool Update(int id, OdontologoCreacionDTO dto)
        {
            var odontologoRepository = new OdontologoRepository();
            var usuarioRepository = new UsuarioRepository();
            var usuario = usuarioRepository.GetByUsername(dto.Username);

            // Validar que el nombre del odontólogo no exista
            if (odontologoRepository.NroMatriculaExists(dto.NroMatricula, id))
            {
                throw new ArgumentException($"Ya existe otro odontólogo con el nombre '{dto.Nombre},' ',{dto.Id}'.");
            }

            Odontologo odontologo = new Odontologo(0, dto.Nombre, dto.Apellido, dto.NroDni, dto.FechaNacimiento, dto.Direccion, dto.Email, dto.Telefono, dto.NroMatricula, usuario);
            return odontologoRepository.Update(odontologo);

        }
    }
}

