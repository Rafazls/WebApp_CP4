using webapplicationcp4.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace webapplicationcp4.Models
{
    public class Circulo : ICalculos2D
    {
        [Range(0.01, double.MaxValue, ErrorMessage = "O raio deve ser maior que zero.")]
        public double Raio { get; set; }

        public Circulo(double raio)
        {
            if (raio <= 0)
                throw new ArgumentException("O raio deve ser maior que zero.", nameof(raio));
            
            Raio = raio;
        }

        public double CalcularArea()
        {
            return Math.PI * Math.Pow(Raio, 2);
        }

        public double CalcularPerimetro()
        {
            return 2 * Math.PI * Raio;
        }
    }
}