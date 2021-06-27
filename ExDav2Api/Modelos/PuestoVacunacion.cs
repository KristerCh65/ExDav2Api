using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExDav2Api.Modelos
{
    public class PuestoVacunacion
    {
        [Key]
        public int IdPuesto { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public string Lugar { get; set; }
        public string Ubicacion { get; set; }
        public string Alias { get; set; }
        public string Direccion { get; set; }

    }
}
