using webapplicationcp4.DTOs;
using webapplicationcp4.Interfaces;
using webapplicationcp4.Models;
using System.Text.Json;

namespace webapplicationcp4.Services
{
    public static class FormaFactory
    {
        public static ICalculos2D? CriarForma2D(FormaRequestDto formaRequest)
        {
            return formaRequest.TipoForma.ToLower() switch
            {
                "circulo" => CriarCirculo(formaRequest.Propriedades),
                "retangulo" => CriarRetangulo(formaRequest.Propriedades),
                _ => null
            };
        }

        public static ICalculos3D? CriarForma3D(FormaRequestDto formaRequest)
        {
            return formaRequest.TipoForma.ToLower() switch
            {
                "esfera" => CriarEsfera(formaRequest.Propriedades),
                _ => null
            };
        }

        private static Circulo? CriarCirculo(JsonElement propriedades)
        {
            if (propriedades.TryGetProperty("raio", out var raioElement) && 
                raioElement.TryGetDouble(out var raio) && raio > 0)
            {
                return new Circulo(raio);
            }
            return null;
        }

        private static Retangulo? CriarRetangulo(JsonElement propriedades)
        {
            if (propriedades.TryGetProperty("largura", out var larguraElement) &&
                propriedades.TryGetProperty("altura", out var alturaElement) &&
                larguraElement.TryGetDouble(out var largura) &&
                alturaElement.TryGetDouble(out var altura) &&
                largura > 0 && altura > 0)
            {
                return new Retangulo(largura, altura);
            }
            return null;
        }

        private static Esfera? CriarEsfera(JsonElement propriedades)
        {
            if (propriedades.TryGetProperty("raio", out var raioElement) && 
                raioElement.TryGetDouble(out var raio) && raio > 0)
            {
                return new Esfera(raio);
            }
            return null;
        }
    }
}