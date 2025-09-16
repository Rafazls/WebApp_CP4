using webapplicationcp4.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace webapplicationcp4.DTOs
{
    [JsonDerivedType(typeof(CirculoDto), "circulo")]
    [JsonDerivedType(typeof(RetanguloDto), "retangulo")]
    [JsonDerivedType(typeof(EsferaDto), "esfera")]
    public abstract class FormaDto
    {
        [Required]
        [JsonPropertyName("tipo")]
        public abstract string Tipo { get; }
    }
}