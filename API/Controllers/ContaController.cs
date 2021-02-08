using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FluentValidation;

namespace API.Controllers
{
    [ApiController]
    
    [Microsoft.AspNetCore.Mvc.Route("Conta")]
    public class ContaController  : ControllerBase
    {
        private readonly IContaService _contaService;

        private readonly ILogger<ContaController> _logger;

        public ContaController(ILogger<ContaController> logger, IContaService contaService)
        {
            _logger = logger;
            _contaService = contaService;
        }

        [HttpPost]
        public async Task<IActionResult > Post([FromBody] Conta conta)
        {
            try
            {
                var result = await _contaService.Add(conta);
                return Ok(result);
            }
            catch (FluentValidation.ValidationException ex)
            {
                return BadRequest(ex.Message);
            }

            return null;
        }
        [HttpGet("Conta")]
        public IActionResult  Get()
        {
            try
            {
                var result = _contaService.Get();
                return Ok(result);
            }
            catch (FluentValidation.ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}