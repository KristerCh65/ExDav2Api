using ExDav2Api.DTOs;
using ExDav2Api.Modelos;
using ExDav2Api.Repositorios.Interface;
using ExDav2Api.Servicios.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExDav2Api.Servicios.Servicio
{
    public class PersonaAppService : IPersonaAppService
    {
        private readonly IPersonaRepositorio personaRepositorio;

        public PersonaAppService(IPersonaRepositorio repositorio)
        {
            personaRepositorio = repositorio;
        }

        public async Task AddPersona(Persona persona)
        {
            await personaRepositorio.AddPersona(persona);
        }

        public async Task<IEnumerable<Persona>> GetPersona()
        {
            return await personaRepositorio.GetPersonas();
        }

        public async Task<PersonaDTO> FindIdPersona(long Dni)
        {
            return await personaRepositorio.FindIdPersona(Dni);
        }

        public async Task<Persona> RemovePersona(int idPersona)
        {
            var personaExist = personaRepositorio.FindIdPersona(idPersona);

            if(personaExist == null)
            {
                new PersonaDTO
                {
                    MensajeFalla = "no existe"
                };
            }

            return await personaRepositorio.RemovePersona(idPersona);
        }
        
        public async Task ActualizarPersona(Persona persona)
        {
            var personaExist = personaRepositorio.FindIdPersona(persona.IdPersona);

            if (personaExist == null)
            {
                  new PersonaDTO
                 {
                     MensajeFalla = "no existe"
                 };
            }

            await personaRepositorio.ActualizarPersona(persona);
        }
    }
}
