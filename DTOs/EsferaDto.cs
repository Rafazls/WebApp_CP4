using webapplicationcp4.Interfaces;
using webapplicationcp4.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace webapplicationcp4.DTOs
{
    public class EsferaDto : FormaDto, ICalculos3D
    {
        public override string Tipo => "esfera";

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "O raio deve ser maior que zero.")]
        [JsonPropertyName("raio")]
        public double Raio { get; set; }

        public double CalcularVolume() => new Esfera(Raio).CalcularVolume();
        public double CalcularAreaSuperficial() => new Esfera(Raio).CalcularAreaSuperficial();
    }
}