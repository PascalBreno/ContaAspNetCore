using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Web.Http;
using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IActionResult > Post([Microsoft.AspNetCore.Mvc.FromBody] Conta conta)
        {
            try
            {

                var result = await _contaService.Add(conta);
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }

            return null;
        }
        [Microsoft.AspNetCore.Mvc.HttpGet("Conta")]
        public async Task<HttpResponse> Get()
        {
            var teste = "123";
            var conta = new Conta();
            var result = await _contaService.Add(conta);

            return null;
        }
    }
}