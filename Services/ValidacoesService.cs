using webapplicationcp4.DTOs;
using webapplicationcp4.Interfaces;
using webapplicationcp4.Models;

namespace webapplicationcp4.Services
{
    public class ValidacoesService : IValidacoesService
    {
        public bool ValidarFormaContida(ICalculos2D formaExterna, ICalculos2D formaInterna)
        {
            return (formaExterna, formaInterna) switch
            {
                (Circulo circuloExt, Circulo circuloInt) => 
                    CirculoContemCirculo(circuloExt, circuloInt),
                
                (Circulo circuloExt, Retangulo retanguloInt) => 
                    CirculoContemRetangulo(circuloExt, retanguloInt),
                
                (Retangulo retanguloExt, Circulo circuloInt) => 
                    RetanguloContemCirculo(retanguloExt, circuloInt),
                
                (Retangulo retanguloExt, Retangulo retanguloInt) => 
                    RetanguloContemRetangulo(retanguloExt, retanguloInt),
                
                _ => false
            };
        }

        private static bool CirculoContemCirculo(Circulo externo, Circulo interno)
        {
            return externo.Raio >= interno.Raio;
        }

        private static bool CirculoContemRetangulo(Circulo externo, Retangulo interno)
        {
            var diagonal = Math.Sqrt(Math.Pow(interno.Largura, 2) + Math.Pow(interno.Altura, 2));
            var raioNecessario = diagonal / 2.0;
            return externo.Raio >= raioNecessario;
        }

        private static bool RetanguloContemCirculo(Retangulo externo, Circulo interno)
        {
            var diametro = interno.Raio * 2;
            return diametro <= externo.Largura && diametro <= externo.Altura;
        }

        private static bool RetanguloContemRetangulo(Retangulo externo, Retangulo interno)
        {
            // Verifica se cabe na orientação normal ou rotacionada
            var cabeNormal = interno.Largura <= externo.Largura && interno.Altura <= externo.Altura;
            var cabeRotacionado = interno.Largura <= externo.Altura && interno.Altura <= externo.Largura;
            
            return cabeNormal || cabeRotacionado;
        }
    }
}