using webapplicationcp4.DTOs;
using webapplicationcp4.Interfaces;
using webapplicationcp4.Services;
using Microsoft.AspNetCore.Mvc;

namespace webapplicationcp4.Controllers
{
    [ApiController]
    [Route("api/v1/calculos")]
    [Produces("application/json")]
    public class CalculosController : ControllerBase
    {
        private readonly ICalculadoraService _calculadoraService;

        public CalculosController(ICalculadoraService calculadoraService)
        {
            _calculadoraService = calculadoraService;
        }

        /// <summary>
        /// Calcula a área de uma forma geométrica 2D.
        /// </summary>
        /// <param name="formaRequest">Dados da forma geométrica para cálculo da área.</param>
        /// <returns>Resultado do cálculo da área.</returns>
        /// <remarks>
        /// Exemplo de requisição para um círculo:
        /// 
        ///     {
        ///         "tipoForma": "circulo",
        ///         "propriedades": {
        ///             "raio": 5.0
        ///         }
        ///     }
        /// 
        /// Exemplo para um retângulo:
        /// 
        ///     {
        ///         "tipoForma": "retangulo",
        ///         "propriedades": {
        ///             "largura": 10.0,
        ///             "altura": 5.0
        ///         }
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">Retorna a área calculada com sucesso.</response>
        /// <response code="400">Dados inválidos ou forma não suporta cálculo de área.</response>
        [HttpPost("area")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult CalcularArea([FromBody] FormaRequestDto formaRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var forma2D = FormaFactory.CriarForma2D(formaRequest);
                if (forma2D == null)
                {
                    return BadRequest($"Tipo de forma '{formaRequest.TipoForma}' não suporta cálculo de área ou propriedades inválidas.");
                }

                var area = _calculadoraService.CalcularArea(forma2D);
                return Ok(new 
                { 
                    tipoForma = formaRequest.TipoForma,
                    area = Math.Round(area, 4),
                    operacao = "area"
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao calcular área: {ex.Message}");
            }
        }

        /// <summary>
        /// Calcula o perímetro de uma forma geométrica 2D.
        /// </summary>
        /// <param name="formaRequest">Dados da forma geométrica para cálculo do perímetro.</param>
        /// <returns>Resultado do cálculo do perímetro.</returns>
        /// <remarks>
        /// Exemplo de requisição para um círculo:
        /// 
        ///     {
        ///         "tipoForma": "circulo",
        ///         "propriedades": {
        ///             "raio": 5.0
        ///         }
        ///     }
        /// 
        /// Exemplo para um retângulo:
        /// 
        ///     {
        ///         "tipoForma": "retangulo",
        ///         "propriedades": {
        ///             "largura": 10.0,
        ///             "altura": 5.0
        ///         }
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">Retorna o perímetro calculado com sucesso.</response>
        /// <response code="400">Dados inválidos ou forma não suporta cálculo de perímetro.</response>
        [HttpPost("perimetro")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult CalcularPerimetro([FromBody] FormaRequestDto formaRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var forma2D = FormaFactory.CriarForma2D(formaRequest);
                if (forma2D == null)
                {
                    return BadRequest($"Tipo de forma '{formaRequest.TipoForma}' não suporta cálculo de perímetro ou propriedades inválidas.");
                }

                var perimetro = _calculadoraService.CalcularPerimetro(forma2D);
                return Ok(new 
                { 
                    tipoForma = formaRequest.TipoForma,
                    perimetro = Math.Round(perimetro, 4),
                    operacao = "perimetro"
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao calcular perímetro: {ex.Message}");
            }
        }

        /// <summary>
        /// Calcula o volume de uma forma geométrica 3D.
        /// </summary>
        /// <param name="formaRequest">Dados da forma geométrica para cálculo do volume.</param>
        /// <returns>Resultado do cálculo do volume.</returns>
        /// <remarks>
        /// Exemplo de requisição para uma esfera:
        /// 
        ///     {
        ///         "tipoForma": "esfera",
        ///         "propriedades": {
        ///             "raio": 5.0
        ///         }
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">Retorna o volume calculado com sucesso.</response>
        /// <response code="400">Dados inválidos ou forma não suporta cálculo de volume.</response>
        [HttpPost("volume")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult CalcularVolume([FromBody] FormaRequestDto formaRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var forma3D = FormaFactory.CriarForma3D(formaRequest);
                if (forma3D == null)
                {
                    return BadRequest($"Tipo de forma '{formaRequest.TipoForma}' não suporta cálculo de volume ou propriedades inválidas.");
                }

                var volume = _calculadoraService.CalcularVolume(forma3D);
                return Ok(new 
                { 
                    tipoForma = formaRequest.TipoForma,
                    volume = Math.Round(volume, 4),
                    operacao = "volume"
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao calcular volume: {ex.Message}");
            }
        }

        /// <summary>
        /// Calcula a área superficial de uma forma geométrica 3D.
        /// </summary>
        /// <param name="formaRequest">Dados da forma geométrica para cálculo da área superficial.</param>
        /// <returns>Resultado do cálculo da área superficial.</returns>
        /// <remarks>
        /// Exemplo de requisição para uma esfera:
        /// 
        ///     {
        ///         "tipoForma": "esfera",
        ///         "propriedades": {
        ///             "raio": 5.0
        ///         }
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">Retorna a área superficial calculada com sucesso.</response>
        /// <response code="400">Dados inválidos ou forma não suporta cálculo de área superficial.</response>
        [HttpPost("area-superficial")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult CalcularAreaSuperficial([FromBody] FormaRequestDto formaRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var forma3D = FormaFactory.CriarForma3D(formaRequest);
                if (forma3D == null)
                {
                    return BadRequest($"Tipo de forma '{formaRequest.TipoForma}' não suporta cálculo de área superficial ou propriedades inválidas.");
                }

                var areaSuperficial = _calculadoraService.CalcularAreaSuperficial(forma3D);
                return Ok(new 
                { 
                    tipoForma = formaRequest.TipoForma,
                    areaSuperficial = Math.Round(areaSuperficial, 4),
                    operacao = "area-superficial"
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao calcular área superficial: {ex.Message}");
            }
        }
    }
}