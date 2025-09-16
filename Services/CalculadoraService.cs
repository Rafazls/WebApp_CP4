using webapplicationcp4.Interfaces;

namespace webapplicationcp4.Services
{
    public class CalculadoraService : ICalculadoraService
    {
        public double CalcularArea(ICalculos2D forma) => forma.CalcularArea();
        public double CalcularPerimetro(ICalculos2D forma) => forma.CalcularPerimetro();
        public double CalcularVolume(ICalculos3D forma) => forma.CalcularVolume();
        public double CalcularAreaSuperficial(ICalculos3D forma) => forma.CalcularAreaSuperficial();
    }
}
        /// <summary>
        /// Verifica se uma forma geométrica pode conter outra forma geométrica.
        /// </summary>
        /// <param name="validacaoRequest">Dados das formas externa e interna para validação.</param>
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