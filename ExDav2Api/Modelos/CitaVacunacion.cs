using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExDav2Api.Modelos
{
    public class CitaVacunacion
    {
        [Key]
        public int IdCita { get; set; }
        public int PuestoVacunacion { get; set; }
        [ForeignKey("IdPuesto")]
        public PuestoVacunacion Puesto { get; set; }
        public string TipoVacuna { get; set; }
        public int NumeroDosis { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public int Persona { get; set; }
        [ForeignKey("IdPersona")]
        public Persona Person { get; set; }

    }
}
