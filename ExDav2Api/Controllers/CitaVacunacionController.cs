using ExDav2Api.DTOs;
using ExDav2Api.Modelos;
using ExDav2Api.Servicios.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExDav2Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaVacunacionController : ControllerBase
    {
        private readonly ICitaVacunacionAppService citasAppService;

        public CitaVacunacionController(ICitaVacunacionAppService citaVacunacionApp)
        {
            citasAppService = citaVacunacionApp;
        }

        [HttpGet]
        public async Task<IActionResult> GetCitas()
        {
            var citas = await citasAppService.GetCitas();
            return Ok(citas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CitaVacunacionDTO>> FindIdCita(int id)
        {
            return await citasAppService.FindIdCitas(id);
        }

        [HttpPost]
        public async Task<IActionResult> AddCita(CitaVacunacion citaVacunacion)
        {
            await citasAppService.AddCitas(citaVacunacion);
            return StatusCode(201);
        }

        [HttpPut("{citaVacunacion}")]
        public async Task<IActionResult> ActualizarCita(CitaVacunacion citaVacunacion)
        {
            await citasAppService.ActualizarCita(citaVacunacion);
            return Ok(citaVacunacion);
        }

        [HttpDelete("{idCita}")]
        public async Task<IActionResult> RemoverCita(int idCita)
        {
            await citasAppService.RemoveCitas(idCita);
            return Ok(idCita);
        }
    }
}
