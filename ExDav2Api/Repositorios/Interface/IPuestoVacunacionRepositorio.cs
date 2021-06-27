using ExDav2Api.DTOs;
using ExDav2Api.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExDav2Api.Repositorios.Interface
{
    public interface IPuestoVacunacionRepositorio
    {
        Task<IEnumerable<PuestoVacunacion>> GetPuestos();
        Task<PuestoVacunacion> AddPuesto(PuestoVacunacion puesto);
        Task<PuestoVacunacion> RemovePuesto(int idPuesto);
        Task<PuestoVacunacionDTO> FindIdPuesto(int idPuesto);
        Task ActualizarPuesto(PuestoVacunacion puesto);
    }
}
