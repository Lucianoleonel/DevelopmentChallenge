using DevelopmentChallenge.Shared;

namespace DevelopmentChallenge.Data.Abstract
{
    /// <summary>
    /// Interfaz que representa una forma geométrica, con métodos para calcular su área y perímetro, y una propiedad para identificar su tipo.
    /// </summary>
    public interface IFormaGeometrica
    {
        EnumsHelper.Formas Tipo { get; }
        decimal CalcularArea();
        decimal CalcularPerimetro();
    }
}
