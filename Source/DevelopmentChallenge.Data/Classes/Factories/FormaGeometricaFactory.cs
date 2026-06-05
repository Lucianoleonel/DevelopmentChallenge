using DevelopmentChallenge.Data.Abstract;
using DevelopmentChallenge.Shared;

namespace DevelopmentChallenge.Data.Classes.Factories
{
    public class FormaGeometricaFactory
    {
        
        public static IFormaGeometrica Crear(EnumsHelper.Formas tipo, decimal lado)
        {
            switch (tipo)
            {
                case EnumsHelper.Formas.Cuadrado:
                    return new Cuadrado(lado);
                case EnumsHelper.Formas.TrianguloEquilatero:
                    return new TrianguloEquilatero(lado);
                case EnumsHelper.Formas.Circulo:
                    return new Circulo(lado);
                case EnumsHelper.Formas.Trapecio:
                    return new Trapecio(lado, lado / 2, lado / 2);
                default:
                    throw new System.ArgumentOutOfRangeException(nameof(tipo), "Forma desconocida");
            }
        }
    }
}
