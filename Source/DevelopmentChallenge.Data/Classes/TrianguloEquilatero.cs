using System;
using DevelopmentChallenge.Data.Abstract;
using DevelopmentChallenge.Shared;

namespace DevelopmentChallenge.Data.Classes
{
    public class TrianguloEquilatero : IFormaGeometrica
    {
        private readonly decimal _lado;

        public TrianguloEquilatero(decimal lado)
        {
            _lado = lado;
        }

        public EnumsHelper.Formas Tipo => EnumsHelper.Formas.TrianguloEquilatero;

        /// <summary>
        /// El área de un triángulo equilátero se calcula con la fórmula: A = (√3 / 4) * lado^2
        /// </summary>
        /// <returns></returns>
        public decimal CalcularArea()
        {
            return ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
        }

        /// <summary>
        /// El perímetro de un triángulo equilátero se calcula con la fórmula: P = 3 * lado
        /// </summary>
        /// <returns></returns>
        public decimal CalcularPerimetro()
        {
            return _lado * 3;
        }
    }
}
