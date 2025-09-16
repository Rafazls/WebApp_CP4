using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace webapplicationcp4.DTOs
{
    public class ValidacaoFormasRequestDto
    {
        [Required]
        [JsonPropertyName("formaExterna")]
        public FormaRequestDto FormaExterna { get; set; } = null!;

        [Required]
        [JsonPropertyName("formaInterna")]
        public FormaRequestDto FormaInterna { get; set; } = null!;
    }
}