using System;
using System.Linq;
using System.Threading.Tasks;
using Application.Arguments.Conta.Adicionar;
using Application.Arguments.Conta.Buscar;
using Application.Interface.Conta;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    
    [Route("Conta")]
    public class ContaController  : ControllerBase
    {
        private readonly IContaAppService _contaAppService;

        public ContaController( IContaAppService contaAppService)
        {
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
                return BadRequest(ex.Errors.Select(x=> new {x.PropertyName, x.ErrorMessage}));
            }
        }
        [HttpGet]
        public IActionResult  Get ([FromQuery] BuscarContaRequest buscarContaRequest)
        {
            try
            {
                var result = _contaAppService.GetAll(buscarContaRequest);
                return Ok(result);
            }
            catch (FluentValidation.ValidationException ex)
            {
                return BadRequest(ex.Errors.Select(x=> new {x.PropertyName, x.ErrorMessage}));
            }
            
        }
        [HttpGet("Id")]
        public IActionResult  GetById([FromQuery] Guid id)
        {
            try
            {
                var result = _contaAppService.GetById(id);
                return Ok(result);
            }
            catch (FluentValidation.ValidationException ex)
            {
                return BadRequest(ex.Errors.Select(x=> new {x.PropertyName, x.ErrorMessage}));
            }
            
        }
    }
}