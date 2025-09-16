using webapplicationcp4.DTOs;
using webapplicationcp4.Interfaces;
using webapplicationcp4.Services;
using Microsoft.AspNetCore.Mvc;

namespace webapplicationcp4.Controllers
{
    [ApiController]
    [Route("api/v1/validacoes")]
    [Produces("application/json")]
    public class ValidacoesController : ControllerBase
    {
        private readonly IValidacoesService _validacoesService;

        public ValidacoesController(IValidacoesService validacoesService)
        {
            _validacoesService = validacoesService;
        }

        /// <summary>
        /// Verifica se uma forma geométrica pode conter outra forma geométrica.
        /// </summary>
        /// <param name="validacaoDto">Dados das formas externa e interna para validação.</param>
        /// <returns>Resultado da validação de contenção.</returns>
        /// <remarks>
        /// Suporta validação para as seguintes combinações:
        /// - Círculo contendo círculo
        /// - Círculo contendo retângulo  
        /// - Retângulo contendo círculo
        /// - Retângulo contendo retângulo
        /// 
        /// Exemplo de requisição (círculo contendo retângulo):
        /// 
        ///     {
        ///         "formaExterna": {
        ///             "tipoForma": "circulo",
        ///             "propriedades": {
        ///                 "raio": 10.0
        ///             }
        ///         },
        ///         "formaInterna": {
        ///             "tipoForma": "retangulo",
        ///             "propriedades": {
        ///                 "largura": 5.0,
        ///                 "altura": 8.0
        ///             }
        ///         }
        ///     }
        /// 
        /// Exemplo de requisição (retângulo contendo círculo):
        /// 
        ///     {
        ///         "formaExterna": {
        ///             "tipoForma": "retangulo",
        ///             "propriedades": {
        ///                 "largura": 20.0,
        ///                 "altura": 15.0
        ///             }
        ///         },
        ///         "formaInterna": {
        ///             "tipoForma": "circulo",
        ///             "propriedades": {
        ///                 "raio": 7.0
        ///             }
        ///         }
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">Retorna o resultado da validação (true se pode conter, false caso contrário).</response>
        /// <response code="400">Dados inválidos ou erro de processamento.</response>
        [HttpPost("forma-contida")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult ValidarFormaContida([FromBody] ValidacaoFormasRequestDto validacaoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Usa o FormaFactory para criar as formas a partir do FormaRequestDto
                var formaExterna = FormaFactory.CriarForma2D(validacaoDto.FormaExterna);
                if (formaExterna == null)
                {
                    return BadRequest($"Forma externa '{validacaoDto.FormaExterna.TipoForma}' não é válida ou propriedades incorretas.");
                }

                var formaInterna = FormaFactory.CriarForma2D(validacaoDto.FormaInterna);
                if (formaInterna == null)
                {
                    return BadRequest($"Forma interna '{validacaoDto.FormaInterna.TipoForma}' não é válida ou propriedades incorretas.");
                }

                var podeConter = _validacoesService.ValidarFormaContida(formaExterna, formaInterna);

                return Ok(new 
                { 
                    formaExterna = validacaoDto.FormaExterna.TipoForma,
                    formaInterna = validacaoDto.FormaInterna.TipoForma,
                    podeConter,
                    validacao = "forma-contida"
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao processar validação: {ex.Message}");
            }
        }
    }
}