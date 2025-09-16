using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace webapplicationcp4.DTOs
{
    public class FormaRequestDto
    {
        [Required]
        [JsonPropertyName("tipoForma")]
        public string TipoForma { get; set; } = string.Empty;

        [Required]
        [JsonPropertyName("propriedades")]
        public JsonElement Propriedades { get; set; }
    }
}