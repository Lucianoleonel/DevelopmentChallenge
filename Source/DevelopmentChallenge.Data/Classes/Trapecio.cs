using System;
using DevelopmentChallenge.Data.Abstract;
using DevelopmentChallenge.Shared;

namespace DevelopmentChallenge.Data.Classes
{
    public class Trapecio : IFormaGeometrica
    {
        private readonly decimal _baseMayor;
        private readonly decimal _baseMenor;
        private readonly decimal _altura;

        public Trapecio(decimal baseMayor, decimal baseMenor, decimal altura)
        {
            _baseMayor = baseMayor;
            _baseMenor = baseMenor;
            _altura = altura;
        }

        public EnumsHelper.Formas Tipo => EnumsHelper.Formas.Trapecio;

        /// <summary>
        /// El área de un trapecio se calcula con la fórmula: A = ((baseMayor + baseMenor) / 2) * altura
        /// </summary>
        /// <returns></returns>
        public decimal CalcularArea() => ((_baseMayor + _baseMenor) / 2) * _altura;

        /// <summary>
        /// El perímetro de un trapecio se calcula con la fórmula: P = baseMayor + baseMenor + 2 * ladoLateral
        /// </summary>
        /// <returns></returns>
        public decimal CalcularPerimetro()
        {
            // Isósceles: los dos lados laterales son iguales
            var diff = (_baseMayor - _baseMenor) / 2;
            var ladoLateral = (decimal)Math.Sqrt((double)(diff * diff + _altura * _altura));
            return _baseMayor + _baseMenor + 2 * ladoLateral;
        }
    }
}
