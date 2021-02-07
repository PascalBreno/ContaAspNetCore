using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
   
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
    public class ContaController  : ApiController
    {
        private readonly IContaService _contaService;

        private readonly ILogger<ContaController> _logger;

        public ContaController(ILogger<ContaController> logger, IContaService contaService)
        {
            _logger = logger;
            _contaService = contaService;
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public IHttpActionResult Post(Conta conta)
        {
            return Ok(_contaService.Add(conta));
        }
    }
}