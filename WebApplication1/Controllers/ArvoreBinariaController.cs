using Builders.Dominio.DataContract;
using Builders.Dominio.Extensions;
using Builders.Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Builders.View.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ArvoreBinariaController : Controller
    {
        private readonly IArvoreService _arvoreService;

        public ArvoreBinariaController(IArvoreService arvoreService)
        {
            this._arvoreService = arvoreService ?? throw new ArgumentNullException(nameof(arvoreService));
        }

        [HttpGet]
        [Route("obter-registros")]
        public IActionResult ObterTodos()
        {
            var _raiz = this._arvoreService.ObterPrimeiroNo();

            var retorno = _raiz.Raiz.ObterEmOrdem();

            return Ok(retorno);
        }

        [HttpPost]
        [Route("inserir-registro")]
        public IActionResult InserirRegistroNaArvore([FromBody] int numero)
        {
            var _raiz = this._arvoreService.ObterPrimeiroNo();
            this._arvoreService.Inserir(numero, _raiz);

            return Ok(new MensagemResponse { Mensagem = "Operação realizada com sucesso." });
        }

    }
}
