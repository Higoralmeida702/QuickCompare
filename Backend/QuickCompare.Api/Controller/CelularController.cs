using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuickCompare.Application.Dto;
using QuickCompare.Application.Interfaces;
using QuickCompare.Domain.Entity;

namespace QuickCompare.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CelularController : ControllerBase
    {
        private readonly ICelularService _service;

        public CelularController(ICelularService celularService)
        {
            _service = celularService;
        }


        [HttpPost]
        public async Task<ActionResult<CelularEntity>> AdicionarCelular([FromBody] CelularDto celularDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await _service.AdicionarCelular(celularDto);
            return Ok(created);
        }


        [HttpGet]
        public async Task<ActionResult<CelularEntity>> BuscarCelularPorId(int id)
        {
            try
            {
                var celular = await _service.ObterCelularPorId(id);
                return Ok(celular);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}