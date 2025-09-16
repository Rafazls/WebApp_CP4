using webapplicationcp4.Interfaces;
using webapplicationcp4.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace webapplicationcp4.DTOs
{
    public class RetanguloDto : FormaDto, ICalculos2D
    {
        public override string Tipo => "retangulo";

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "A largura deve ser maior que zero.")]
        [JsonPropertyName("largura")]
        public double Largura { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "A altura deve ser maior que zero.")]
        [JsonPropertyName("altura")]
        public double Altura { get; set; }

        public double CalcularArea() => new Retangulo(Largura, Altura).CalcularArea();
        public double CalcularPerimetro() => new Retangulo(Largura, Altura).CalcularPerimetro();
    }
}
