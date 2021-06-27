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
    public class CitasVacunacionAppService : ICitaVacunacionAppService
    {
        private readonly ICitaVacunacionRepositorio vacunacionReporsitorio;

        public CitasVacunacionAppService(ICitaVacunacionRepositorio citaVacunacion)
        {
            vacunacionReporsitorio = citaVacunacion;
        }

        public CitasVacunacionAppService()
        {
        }

        public async Task AddCitas(CitaVacunacion cita)
        {
            await vacunacionReporsitorio.AddCitas(cita);
        }

        public async Task<IEnumerable<CitaVacunacion>> GetCitas()
        {
            return await vacunacionReporsitorio.GetCitas();
        }

        public async Task<CitaVacunacionDTO> FindIdCitas(int idCita)
        {
            return await vacunacionReporsitorio.FindIdCitas(idCita);
        }

        public async Task<CitaVacunacion> RemoveCitas(int IdCita)
        {
            var citaExist = vacunacionReporsitorio.FindIdCitas(IdCita);

            if (citaExist == null)
            {
                new CitaVacunacionDTO
                {
                    MensajeFalla = "no existe"
                };
            }

            return await vacunacionReporsitorio.RemoveCitas(IdCita);
        }

        public async Task ActualizarCita(CitaVacunacion cita)
        {
            var citaExist = vacunacionReporsitorio.FindIdCitas(cita.IdCita);

            if (citaExist == null)
            {
                new CitaVacunacionDTO
                {
                    MensajeFalla = "no existe"
                };
            }

            await vacunacionReporsitorio.ActualizarCita(cita);
        }
    }
}
