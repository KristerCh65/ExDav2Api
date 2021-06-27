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
    public class PuestoVacunacionRepositorio : IPuestoVacunacionRepositorio
    {
        private readonly CoviContext coviContext;

        public PuestoVacunacionRepositorio(CoviContext context)
        {
            coviContext = context;
        }

        public async Task<PuestoVacunacion> AddPuesto(PuestoVacunacion puesto)
        {
            await coviContext.PuestosVacunacion.AddAsync(puesto);
            await coviContext.SaveChangesAsync();
            return puesto;
        }

        public async Task<PuestoVacunacion> RemovePuesto(int puesto)
        {
            var DataPuesto = await coviContext.PuestosVacunacion.FindAsync(puesto);

            if (DataPuesto == null)
            {
                return null;
            }

            coviContext.PuestosVacunacion.Remove(DataPuesto);
            return DataPuesto;
        }

        public async Task<PuestoVacunacionDTO> FindIdPuesto(int idPuesto)
        {
            var findPuesto = await coviContext.PuestosVacunacion.FirstOrDefaultAsync(p => p.IdPuesto == idPuesto);

            if (findPuesto == null)
            {
                return new PuestoVacunacionDTO
                {
                    MensajeFalla = "Puesto no encontrado"
                };
            }

            return new PuestoVacunacionDTO
            {
                IdPuesto = findPuesto.IdPuesto,
                Lugar = findPuesto.Lugar,
                Municipio = findPuesto.Municipio,
                Departamento = findPuesto.Departamento,
                Direccion = findPuesto.Direccion,
                Alias = findPuesto.Alias,
                Ubicacion = findPuesto.Ubicacion
            };
        }

        public async Task<IEnumerable<PuestoVacunacion>> GetPuestos()
        {
            return await coviContext.PuestosVacunacion.ToListAsync();
        }

        public async Task ActualizarPuesto(PuestoVacunacion puesto)
        {
            coviContext.Entry(puesto).State = EntityState.Modified;
            await coviContext.SaveChangesAsync();
        }

    }
}
