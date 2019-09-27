using System.Collections.Generic;
using DesafioSelecao.Aplicacao;
using DesafioSelecao.Aplicacao.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioSelecao.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class FamiliasController : Controller
    {
        private readonly IClassificacaoDeFamilias _classificacaoDeFamilias;

        public FamiliasController(IClassificacaoDeFamilias classificacaoDeFamilias)
        {
            _classificacaoDeFamilias = classificacaoDeFamilias;
        }

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public IActionResult ClassificarFamilias([FromBody] FamiliaDto[] familias)
        {
            _classificacaoDeFamilias.Classificar(familias);

            return Json(Ok());
        }
    }
}