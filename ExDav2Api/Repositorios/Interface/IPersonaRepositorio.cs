using ExDav2Api.DTOs;
using ExDav2Api.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExDav2Api.Repositorios.Interface
{
    public interface IPersonaRepositorio
    {
        Task<IEnumerable<Persona>> GetPersonas();
        Task AddPersona(Persona persona);
        Task<Persona> RemovePersona(int idPersona);
        Task<PersonaDTO> FindIdPersona(long DniPersona);
        Task ActualizarPersona(Persona persona);

    }
}
