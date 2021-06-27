using ExDav2Api.DTOs;
using ExDav2Api.Modelos;
using ExDav2Api.Servicios.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExDav2Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaAppService personaApp;

        public PersonaController(IPersonaAppService personaAppService)
        {
            personaApp = personaAppService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPersona()
        {
            var person = await personaApp.GetPersona();
            return Ok(person);
        }

        [HttpGet("{dni}")]
        public async Task<ActionResult<PersonaDTO>> FindIdPersona(long dni)
        {
            return await personaApp.FindIdPersona(dni);
        }

        [HttpPost]
        public async Task<IActionResult> AddPersona(Persona persona)
        {
            await personaApp.AddPersona(persona);
            return  StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarPersona(int id, Persona persona)
        {
            if(id != persona.IdPersona)
            {
                return BadRequest();
            }
            await personaApp.ActualizarPersona(persona);
            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemovePersona(int id)
        {
            await personaApp.RemovePersona(id);
            return Ok(id);

        }
    }
}
