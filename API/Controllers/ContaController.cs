using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Application.Arguments.Conta.Adicionar;
using Application.Arguments.Conta.Buscar;
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
    
    [Microsoft.AspNetCore.Mvc.Route("Conta")]
    public class ContaController  : ControllerBase
    {
        private readonly IContaAppService _contaAppService;

        public ContaController( IContaAppService contaAppService)
        {
            _contaAppService = contaAppService;
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IActionResult > Post([Microsoft.AspNetCore.Mvc.FromBody] AdicionarContaRequest conta)
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
        [Microsoft.AspNetCore.Mvc.HttpGet]
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
        [Microsoft.AspNetCore.Mvc.HttpGet("Id")]
        public IActionResult  GetById([FromQuery] Guid Id)
        {
            try
            {
                var result = _contaAppService.GetById(Id);
                return Ok(result);
            }
            catch (FluentValidation.ValidationException ex)
            {
                return BadRequest(ex.Errors.Select(x=> new {x.PropertyName, x.ErrorMessage}));
            }
            
        }
    }
}