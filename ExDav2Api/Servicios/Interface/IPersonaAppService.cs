using ExDav2Api.DTOs;
using ExDav2Api.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExDav2Api.Servicios.Interface
{
    public interface IPersonaAppService
    {
        Task<IEnumerable<Persona>> GetPersona();
        Task AddPersona(Persona persona);
        Task<Persona> RemovePersona(int idPersona);
        Task<PersonaDTO> FindIdPersona(long idPersona);
        Task ActualizarPersona(Persona persona);
    }
}
