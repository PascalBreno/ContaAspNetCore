using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Application.Arguments.Conta.Adicionar;
using Application.Interface.Conta;
using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FluentValidation;
using FluentValidation.TestHelper;

namespace API.Controllers
{
    [ApiController]
    
    [Route("Conta")]
    public class ContaController  : ControllerBase
    {
        private readonly IContaAppService _contaAppService;
        private readonly ILogger<ContaController> _logger;

        public ContaController(ILogger<ContaController> logger, IContaAppService contaAppService)
        {
            _logger = logger;
            _contaAppService = contaAppService;
        }

        [HttpPost]
        public async Task<IActionResult > Post([FromBody] AdicionarContaRequest conta)
        {
            try
            {
                var result = await _contaAppService.Add(conta);
                return Ok(result);
            }
            catch (FluentValidation.ValidationException ex)
            {
                return BadRequest(ex.Errors.FirstOrDefault().ErrorMessage);
            }
        }
        [HttpGet]
        public IActionResult  Get()
        {
            try
            {
                var result = _contaAppService.GetAll();
                return Ok(result);
            }
            catch (FluentValidation.ValidationException ex)
            {
                return BadRequest(ex.Errors.FirstOrDefault().ErrorMessage);
            }
            
        }
    }
}