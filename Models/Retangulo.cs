using webapplicationcp4.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace webapplicationcp4.Models{
    public class Retangulo : ICalculos2D
    {
        [Range(0.01, double.MaxValue, ErrorMessage = "A largura deve ser maior que zero.")]
        public double Largura { get; set; }
        
        [Range(0.01, double.MaxValue, ErrorMessage = "A altura deve ser maior que zero.")]
        public double Altura { get; set; }

        public Retangulo(double largura, double altura)
        {
            if (largura <= 0)
                throw new ArgumentException("A largura deve ser maior que zero.", nameof(largura));
            if (altura <= 0)
                throw new ArgumentException("A altura deve ser maior que zero.", nameof(altura));
                
            Largura = largura;
            Altura = altura;
        }

        public double CalcularArea()
        {
            return Largura * Altura;
        }

        public double CalcularPerimetro()
        {
            return 2 * (Largura + Altura); // CORRIGIDO: estava multiplicando em vez de somar
        }
    }
}