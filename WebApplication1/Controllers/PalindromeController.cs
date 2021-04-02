using Builders.Dominio.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Builders.View.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PalindromeController : Controller
    {
        [HttpPost]
        public IActionResult Index([FromBody] string frase)
        {
            if (frase.IsPalindrome())
                return Ok($"A Palavra ({frase}) é um Palíndromo");
            else
                return Ok($"A Palavra ({frase}) não um Palíndromo");
        }
    }
}
