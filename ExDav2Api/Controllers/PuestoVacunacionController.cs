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
    public class PuestoVacunacionController : ControllerBase
    {
        private readonly IPuestoVacunacionAppService puestoVacunacionApp;

        public PuestoVacunacionController(IPuestoVacunacionAppService puestoVacunacionAppService)
        {
            puestoVacunacionApp = puestoVacunacionAppService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPuestos()
        {
            var puesto = await puestoVacunacionApp.GetPuestos();
            return Ok(puesto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PuestoVacunacionDTO>> FindIdPuesto(int puesto)
        {
            return await puestoVacunacionApp.FindIdPuesto(puesto);
        }

        [HttpPost]
        public async Task<IActionResult> AddPuesto(PuestoVacunacion puestoVacunacion)
        {
            await puestoVacunacionApp.AddPuesto(puestoVacunacion);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarPuesto(PuestoVacunacion puestoVacunacion, int idPuesto)
        {
            if(idPuesto != puestoVacunacion.IdPuesto)
            {
                return BadRequest();
            }
            await puestoVacunacionApp.ActualizarPuesto(puestoVacunacion);
            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverPuesto(int puestoVacunacionId)
        {
            await puestoVacunacionApp.RemovePuesto(puestoVacunacionId);
            return Ok(puestoVacunacionId);
        }
    }
}
