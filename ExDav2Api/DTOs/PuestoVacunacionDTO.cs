using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExDav2Api.DTOs
{
    public class PuestoVacunacionDTO
    {
        public int IdPuesto { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public string Lugar { get; set; }
        public string Ubicacion { get; set; }
        public string Alias { get; set; }
        public string Direccion { get; set; }
        public string MensajeFalla { get; set; }
    }
}
