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
    public class CitaVacunacionRepositorio : ICitaVacunacionRepositorio
    {
        private readonly CoviContext coviContext;

        public CitaVacunacionRepositorio( CoviContext context)
        {
            coviContext = context;
        }

        public async Task<CitaVacunacion> AddCitas(CitaVacunacion cita)
        {
            await coviContext.AddAsync(cita);
            await coviContext.SaveChangesAsync();
            return cita;
        }

        public async Task<CitaVacunacion> RemoveCitas(int cita)
        {
            var DataCita = await coviContext.CitasVacunacion.FindAsync(cita);

            if (DataCita == null)
            {
                return null;
            }

            coviContext.CitasVacunacion.Remove(DataCita);
            return DataCita;
        }

        public async Task<CitaVacunacionDTO> FindIdCitas(int idCita)
        {
            var findCita = await coviContext.CitasVacunacion.Include(p => p.Person).Include(v => v.Puesto).FirstOrDefaultAsync(p => p.IdCita == idCita);

            if (findCita == null)
            {
                return new CitaVacunacionDTO
                {
                    MensajeFalla = "Puesto no encontrado"
                };
            }

            return new CitaVacunacionDTO
            {
                IdCita = findCita.IdCita,
                Hora = findCita.Hora,
                Fecha = findCita.Fecha,
                NumeroDosis = findCita.NumeroDosis,
                Persona =  findCita.Persona,
                PuestoVacunacion = findCita.PuestoVacunacion,
                TipoVacuna = findCita.TipoVacuna
            };
        }

        public async Task<IEnumerable<CitaVacunacion>> GetCitas()
        {
            return await coviContext.CitasVacunacion.Include(p => p.Person).Include(v => v.Puesto).ToListAsync();
        }

        public async Task ActualizarCita(CitaVacunacion cita)
        {
            coviContext.Entry(cita).State = EntityState.Modified;
            await coviContext.SaveChangesAsync();
        }

    }
}
