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
    public class PuestoVacunacionAppService : IPuestoVacunacionAppService
    {
        private readonly IPuestoVacunacionRepositorio vacunacionRepositorio;
        
        public PuestoVacunacionAppService(IPuestoVacunacionRepositorio puestoVacunacion)
        {
            vacunacionRepositorio = puestoVacunacion;
        }

        public async Task AddPuesto(PuestoVacunacion puesto)
        {
            await vacunacionRepositorio.AddPuesto(puesto);
        }

        public async Task<IEnumerable<PuestoVacunacion>> GetPuestos()
        {
            return await vacunacionRepositorio.GetPuestos();
        }

        public async Task<PuestoVacunacionDTO> FindIdPuesto(int IdPuesto)
        {
            return await vacunacionRepositorio.FindIdPuesto(IdPuesto);
        }

        public async Task<PuestoVacunacion> RemovePuesto(int idPuesto)
        {
            var puestoExist = vacunacionRepositorio.FindIdPuesto(idPuesto);

            if (puestoExist == null)
            {
                new PuestoVacunacionDTO
                {
                    MensajeFalla = "no existe"
                };
            }

            return await vacunacionRepositorio.RemovePuesto(idPuesto);
        }

        public async Task ActualizarPuesto(PuestoVacunacion puesto)
        {
            var puestoExist = vacunacionRepositorio.FindIdPuesto(puesto.IdPuesto);

            if (puestoExist == null)
            {
                new PuestoVacunacionDTO
                {
                    MensajeFalla = "no existe"
                };
            }

            await vacunacionRepositorio.ActualizarPuesto(puesto);
        }
    }
}
