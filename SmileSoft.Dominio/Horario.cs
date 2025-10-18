using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileSoft.Dominio
{
    public enum DiaDeLaSemana
    {
        //Domingo = 0, se considera que tanto domingo como sabado no se trabaja en la clinica
        Lunes = 1,
        Martes = 2,
        Miercoles = 3,
        Jueves = 4,
        Viernes = 5,
        //Sabado = 6
    }
    public class Horario
    {
        public int Id { get; set; }
        public DiaDeLaSemana DiaDeLaSemana { get; set; }
        public TimeSpan HoraDesde { get; set; }
        public TimeSpan HoraHasta { get; set; }
        public int OdontologoId { get; set; }
        public Odontologo Odontologo { get; set; }
        public Horario()
        {
        }
    }
}
