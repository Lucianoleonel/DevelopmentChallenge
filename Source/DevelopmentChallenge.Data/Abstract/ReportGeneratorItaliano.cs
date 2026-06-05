using DevelopmentChallenge.Shared;
using System.Collections.Generic;

namespace DevelopmentChallenge.Data.Abstract
{
    public class ReportGeneratorItaliano : ReportGeneratorBase
    {
        public ReportGeneratorItaliano() : base(
            new Dictionary<EnumsHelper.Formas , string>
            {
                { EnumsHelper.Formas.Cuadrado, "Quadrato" },
                { EnumsHelper.Formas.Circulo, "Cerchio" },
                { EnumsHelper.Formas.TrianguloEquilatero, "Triangolo" },
                { EnumsHelper.Formas.Trapecio, "Trapezio" }
            },
            new Dictionary<EnumsHelper.Formas , string>
            {
                { EnumsHelper.Formas.Cuadrado, "Quadrati" },
                { EnumsHelper.Formas.Circulo, "Cerchi" },
                { EnumsHelper.Formas.TrianguloEquilatero, "Triangoli" },
                { EnumsHelper.Formas.Trapecio, "Trapezi" }
            })
        { }

        protected override string MensajeListaVacia => "Lista vuota di forme!";
        protected override string Encabezado => "Rapporto sulle forme";
        protected override string EtiquetaFormas => "forme";
        protected override string EtiquetaPerimetro => "Perimetro";
    }
}
