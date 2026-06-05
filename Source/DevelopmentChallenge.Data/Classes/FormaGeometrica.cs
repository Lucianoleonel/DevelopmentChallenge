/******************************************************************************************************************/
/******* ¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas? *******/
/******************************************************************************************************************/

/*
 * TODO: 
 * Refactorizar la clase para respetar principios de la programación orientada a objetos.
 * Implementar la forma Trapecio/Rectangulo. 
 * Agregar el idioma Italiano (o el deseado) al reporte.
 * Se agradece la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad agregada (los tests deben pasar correctamente al entregar la solución, incluso los actuales.)
 * Una vez finalizado, hay que subir el código a un repo GIT y ofrecernos la URL para que podamos utilizar la nueva versión :).
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevelopmentChallenge.Data.Abstract;
using DevelopmentChallenge.Data.Classes.Factories;
using DevelopmentChallenge.Shared;

namespace DevelopmentChallenge.Data.Classes
{
    public class FormaGeometrica
    {
        
        private readonly decimal _lado;

        public EnumsHelper.Formas Tipo { get; set; }

        public FormaGeometrica(EnumsHelper.Formas tipo, decimal ancho)
        {
            Tipo = tipo;
            _lado = ancho;
        }

        /// <summary>
        /// Genera un reporte de las formas geométricas recibidas en el idioma especificado.
        /// </summary>
        /// <param name="formas"></param>
        /// <param name="idioma"></param>
        /// <returns></returns>
        public static string Imprimir(List<FormaGeometrica> formas, EnumsHelper.Idiomas idioma)
        {
            
            List<IFormaGeometrica> formasInterface = new List<IFormaGeometrica>();

            foreach (FormaGeometrica forma in formas)
            {
                formasInterface.Add(FormaGeometricaFactory.Crear(forma.Tipo, forma.ObtenerLado()));
            }

            // Obtener el generador de reporte según el idioma
            IReportGenerator generador = ReportGeneratorFactory.Crear(idioma);

            // Generar y retornar el reporte
            return generador.Generar(formasInterface);
        }

        /// <summary>
        /// Obtiene el lado de la forma geométrica, que puede representar el lado del cuadrado, el diámetro del círculo o el lado del triángulo equilátero.
        /// </summary>
        /// <returns></returns>
        internal decimal ObtenerLado()
        {
            return _lado;
        }

        /// <summary>
        /// Calcula el área de la forma geométrica según su tipo.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public decimal CalcularArea()
        {
            switch (Tipo)
            {
                case EnumsHelper.Formas.Cuadrado: return _lado * _lado;
                case EnumsHelper.Formas.Circulo: return (decimal)Math.PI * (_lado / 2) * (_lado / 2);
                case EnumsHelper.Formas.TrianguloEquilatero: return ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
                default:
                    throw new ArgumentOutOfRangeException(@"Forma desconocida");
            }
        }

        public decimal CalcularPerimetro()
        {
            switch (Tipo)
            {
                case EnumsHelper.Formas.Cuadrado: return _lado * 4;
                case EnumsHelper.Formas.Circulo: return (decimal)Math.PI * _lado;
                case EnumsHelper.Formas.TrianguloEquilatero: return _lado * 3;
                default:
                    throw new ArgumentOutOfRangeException(@"Forma desconocida");
            }
        }
    }
}
