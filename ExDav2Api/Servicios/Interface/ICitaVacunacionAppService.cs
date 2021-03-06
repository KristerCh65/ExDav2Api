using ExDav2Api.DTOs;
using ExDav2Api.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExDav2Api.Servicios.Interface
{
    public interface ICitaVacunacionAppService
    {
        Task<IEnumerable<CitaVacunacion>> GetCitas();
        Task AddCitas(CitaVacunacion cita);
        Task<CitaVacunacion> RemoveCitas(int idCita);
        Task<CitaVacunacionDTO> FindIdCitas(int idCita);
        Task ActualizarCita(CitaVacunacion cita);
    }
}
