using System.Collections.Generic;
using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Shared;

namespace DevelopmentChallenge.Data.Abstract
{
    public class ReportGeneratorCastellano : ReportGeneratorBase
    {
        public ReportGeneratorCastellano() : base(
            new Dictionary<EnumsHelper.Formas , string>
            {
                { EnumsHelper.Formas.Cuadrado , "Cuadrado" },
                { EnumsHelper.Formas.Circulo , "Círculo" },
                { EnumsHelper.Formas.TrianguloEquilatero , "Triángulo" },
                { EnumsHelper.Formas.Trapecio, "Trapecio" }
            },
            new Dictionary<EnumsHelper.Formas, string>
            {
                { EnumsHelper.Formas.Cuadrado, "Cuadrados" },
                { EnumsHelper.Formas.Circulo, "Círculos" },
                { EnumsHelper.Formas.TrianguloEquilatero, "Triángulos" },
                { EnumsHelper.Formas.Trapecio, "Trapecios" }
            })
            { }

        protected override string MensajeListaVacia => "Lista vacía de formas!";
        protected override string Encabezado => "Reporte de Formas";
        protected override string EtiquetaFormas => "formas";
        protected override string EtiquetaPerimetro => "Perimetro";
    }
}
