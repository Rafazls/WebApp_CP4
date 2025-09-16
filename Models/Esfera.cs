using webapplicationcp4.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace webapplicationcp4.Models
{
    public class Esfera : ICalculos3D
    {
        [Range(0.01, double.MaxValue, ErrorMessage = "O raio deve ser maior que zero.")]
        public double Raio { get; set; }

        public Esfera(double raio)
        {
            if (raio <= 0)
                throw new ArgumentException("O raio deve ser maior que zero.", nameof(raio));
                
            Raio = raio;
        }

        public double CalcularVolume()
        {
            return (4.0 / 3.0) * Math.PI * Math.Pow(Raio, 3);
        }

        public double CalcularAreaSuperficial()
        {
            return 4 * Math.PI * Math.Pow(Raio, 2);
        }
    }
}