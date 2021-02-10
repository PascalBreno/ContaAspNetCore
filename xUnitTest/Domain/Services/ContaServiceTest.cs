using System;
using CrossCrutting.Enum;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Service;
using FluentValidation;
using Moq;
using Xunit;
using Range = Moq.Range;

namespace xUnitTest.Domain.Services
{
    public class ContaServiceTest
    {
        private readonly ContaService _contaService;
        private readonly Mock<IValidator<Conta>> _validatorMock;
        private readonly Mock<IContaRepository> _contaRepositoryMock;
        public ContaServiceTest()
        {
            _contaRepositoryMock = new Mock<IContaRepository>();
            _validatorMock = new Mock<IValidator<Conta>>();
            _contaService = new ContaService(_validatorMock.Object, _contaRepositoryMock.Object);
        }

        [Fact]
        public async void Add_ValidarEAdicionarConta_Sucesso()
        {
            
            //arrange 
            var contaTest = new Conta
            {
                Nome="Nome Teste",
                DataPagamento = new DateTime(09-05-1998),
                DataVencimento =new DateTime(09-05-2000),
                ValorOriginal = 1000
            };

            _contaRepositoryMock.Setup(x => x.Add(contaTest))
                .ReturnsAsync(contaTest);
            
            // action

            var contaResult = await _contaService.Add(contaTest);

            // assert 
            _contaRepositoryMock.Verify(x=>x.Add(contaTest), Times.Once);
            Assert.True(contaResult.ValorCorrigido>0.0);
            Assert.True(contaResult.Status==StatusEnum.PagoComAtraso);
        }

        [Fact]
        //double VerificacaoAcrescimo(int dias, double multa, double juros, double valorOriginal)
        public void Add_VerificarJuros_Ate3Dias_Sucess()
        {
            //Verificando com até 3 dias de atraso
            // arrange
            var dias = 3;
            var multa = 2;
            var juros = 0.1;
            var valorOriginal = 1000;
            
            // action
            var contaResult =  _contaService.VerificacaoAcrescimo(dias, multa, juros, valorOriginal);
            // assert
            Assert.Equal(23, contaResult);

        }
        [Fact]
        public void Add_VerificarJuros_Ate5Dias_Sucess()
        {
            //Verificando com até 3 dias de atraso
            // arrange
            var dias = 3;
            var multa = 2;
            var juros = 0.1;
            var valorOriginal = 1000;
            
            // action
            var contaResult =  _contaService.VerificacaoAcrescimo(dias, multa, juros, valorOriginal);
            // assert
            Assert.Equal(23, contaResult);

        }
        [Fact]
        public void Add_VerificarJuros_Ate7Dias_Sucess()
        {
            //Verificando com até 3 dias de atraso
            // arrange
            var dias = 3;
            var multa = 2;
            var juros = 0.1;
            var valorOriginal = 1000;
            
            // action
            var contaResult =  _contaService.VerificacaoAcrescimo(dias, multa, juros, valorOriginal);
            // assert
            Assert.Equal(23, contaResult);

        }
        
    }
}