using webapplicationcp4.Interfaces;
using webapplicationcp4.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace webapplicationcp4.DTOs
{
    public class CirculoDto : FormaDto, ICalculos2D
    {
        public override string Tipo => "circulo";

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "O raio deve ser maior que zero.")]
        [JsonPropertyName("raio")]
        public double Raio { get; set; }

        public double CalcularArea() => new Circulo(Raio).CalcularArea();
        public double CalcularPerimetro() => new Circulo(Raio).CalcularPerimetro();
    }
}