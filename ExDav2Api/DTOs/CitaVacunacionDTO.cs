using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExDav2Api.DTOs
{
    public class CitaVacunacionDTO
    {
        public int IdCita { get; set; }
        public int PuestoVacunacion { get; set; }
        public string TipoVacuna { get; set; }
        public int NumeroDosis { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public int Persona { get; set; }
        public string MensajeFalla { get; set; }
    }
}
