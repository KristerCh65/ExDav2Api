using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExDav2Api.DTOs
{
    public class PersonaDTO
    {
        public int IdPersona { get; set; }
        public long DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public string Direccion { get; set; }
        public string LugarReside { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string PuntoReferencia { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public bool AfiliadoIhss { get; set; }
        public string NivelEducativo { get; set; }
        public string MensajeFalla { get; set; }
    }
}
