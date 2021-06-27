using ExDav2Api.Data;
using ExDav2Api.DTOs;
using ExDav2Api.Modelos;
using ExDav2Api.Repositorios.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExDav2Api.Repositorios.Repositorio
{
    public class PersonaRepositorio : IPersonaRepositorio
    {
        private readonly CoviContext coviContext;

        public PersonaRepositorio(CoviContext context)
        {
            coviContext = context;
        }

        public async Task<Persona> AddPersona(Persona persona)
        {
            await coviContext.AddAsync(persona);
            await coviContext.SaveChangesAsync();
            return persona;
        }

        public async Task<Persona> RemovePersona(int persona)
        {
            var DataPersona = await coviContext.Personas.FindAsync(persona);

            if (DataPersona == null)
            {
                return null;
            }

            coviContext.Personas.Remove(DataPersona);
            return DataPersona;
        }

        public async Task<PersonaDTO> FindIdPersona(long DniPersona)
        {
            var findPersona = await coviContext.Personas.FirstOrDefaultAsync(p => p.DNI == DniPersona);

            if (findPersona == null)
            {
                return new PersonaDTO
                {
                    MensajeFalla = "DNI invalido"
                };
            }

            return new PersonaDTO
            {
                IdPersona = findPersona.IdPersona,
                DNI = findPersona.DNI,
                Direccion = findPersona.Direccion,
                Municipio = findPersona.Municipio,
                LugarReside = findPersona.LugarReside,
                AfiliadoIhss = findPersona.AfiliadoIhss,
                Apellidos = findPersona.Apellidos,
                NivelEducativo = findPersona.NivelEducativo,
                Nombre = findPersona.Nombre,
                PuntoReferencia = findPersona.PuntoReferencia,
                Telefono = findPersona.Telefono,
                Correo = findPersona.Correo,
                Departamento = findPersona.Departamento,
                FechaNacimiento = findPersona.FechaNacimiento
            };
        }

        public async Task<IEnumerable<Persona>> GetPersonas()
        {
            return await coviContext.Personas.ToListAsync();
        }

        public async Task ActualizarPersona(Persona persona)
        {
            coviContext.Entry(persona).State = EntityState.Modified;
            await coviContext.SaveChangesAsync();
        }


    }


}
