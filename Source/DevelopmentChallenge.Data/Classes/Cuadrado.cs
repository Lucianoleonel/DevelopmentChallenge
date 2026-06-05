using DevelopmentChallenge.Data.Abstract;
using DevelopmentChallenge.Shared;

namespace DevelopmentChallenge.Data.Classes
{
    public class Cuadrado : IFormaGeometrica
    {
        private readonly decimal _lado;

        public Cuadrado(decimal lado)
        {
            _lado = lado;
        }

        public EnumsHelper.Formas Tipo => EnumsHelper.Formas.Cuadrado;

        public decimal CalcularArea()
        {
            return _lado * _lado;
        }

        public decimal CalcularPerimetro()
        {
            return _lado * 4;
        }
    }
}
