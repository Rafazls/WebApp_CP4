namespace webapplicationcp4.Interfaces
{
    public interface IValidacoesService
    {
        bool ValidarFormaContida(ICalculos2D formaExterna, ICalculos2D formaInterna);
    }
}