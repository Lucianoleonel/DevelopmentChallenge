using System;
using DevelopmentChallenge.Data.Abstract;
using DevelopmentChallenge.Shared;

namespace DevelopmentChallenge.Data.Classes
{
    public class Circulo : IFormaGeometrica
    {
        private readonly decimal _diametro;

        public Circulo(decimal diametro)
        {
            _diametro = diametro;
        }

        public EnumsHelper.Formas Tipo => EnumsHelper.Formas.Circulo;

        public decimal CalcularArea()
        {
            return (decimal)Math.PI * (_diametro / 2) * (_diametro / 2);
        }

        public decimal CalcularPerimetro()
        {
            return (decimal)Math.PI * _diametro;
        }
    }
}
