using System.Collections.Generic;
using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Shared;

namespace DevelopmentChallenge.Data.Abstract
{
    public class ReportGeneratorIngles : ReportGeneratorBase
    {
        public ReportGeneratorIngles() : base(
            new Dictionary<EnumsHelper.Formas , string>
            {
                { EnumsHelper.Formas.Cuadrado, "Square" },
                { EnumsHelper.Formas.Circulo, "Circle" },
                { EnumsHelper.Formas.TrianguloEquilatero, "Triangle" },
                { EnumsHelper.Formas.Trapecio, "Trapezoid" }
            },
            new Dictionary<EnumsHelper.Formas, string>
            {
                { EnumsHelper.Formas.Cuadrado, "Squares" },
                { EnumsHelper.Formas.Circulo, "Circles" },
                { EnumsHelper.Formas.TrianguloEquilatero, "Triangles" },
                { EnumsHelper.Formas.Trapecio, "Trapezoids" }
            })
        { }

        protected override string MensajeListaVacia => "Empty list of shapes!";
        protected override string Encabezado => "Shapes report";
        protected override string EtiquetaFormas => "shapes";
        protected override string EtiquetaPerimetro => "Perimeter";
    }
}
