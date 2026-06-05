using DevelopmentChallenge.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevelopmentChallenge.Data.Abstract
{

    /// <summary>
    /// Clase base para generar reportes de formas geométricas. Implementa la lógica común para generar el reporte, mientras que las clases derivadas proporcionan los textos específicos para cada idioma.
    /// </summary>
    public abstract class ReportGeneratorBase : IReportGenerator
    {
        private readonly Dictionary<EnumsHelper.Formas, string> _singular;
        private readonly Dictionary<EnumsHelper.Formas , string> _plural;
        
        protected ReportGeneratorBase(Dictionary<EnumsHelper.Formas, string> singular, Dictionary<EnumsHelper.Formas, string> plural)
        {
            _singular = singular;
            _plural = plural;
        }

        protected abstract string MensajeListaVacia { get; }
        protected abstract string Encabezado { get; }
        protected abstract string EtiquetaFormas { get; }
        protected abstract string EtiquetaPerimetro { get; }

        /// <summary>
        /// Genera un reporte en formato HTML a partir de una lista de formas geométricas. El reporte incluye el número de cada tipo de forma, su área total y su perímetro total, así como un resumen final con el total de formas, área y perímetro.
        /// </summary>
        /// <param name="formas"></param>
        /// <returns></returns>
        public string Generar(List<IFormaGeometrica> formas)
        {
            StringBuilder sb = new StringBuilder();

            if (!formas.Any())
            {
                sb.Append($"<h1>{MensajeListaVacia}</h1>");
            }
            else
            {
                sb.Append($"<h1>{Encabezado}</h1>");

                decimal totalArea = 0, totalPerimetro = 0;
                int totalFormas = 0;

                foreach (var grupo in formas.GroupBy(f => f.Tipo))
                {
                    var count = grupo.Count();
                    var area = grupo.Sum(f => f.CalcularArea());
                    var perimetro = grupo.Sum(f => f.CalcularPerimetro());
                    var nombre = count == 1 ? _singular[grupo.Key] : _plural[grupo.Key];

                    sb.Append($"{count} {nombre} | Area {area:#.##} | {EtiquetaPerimetro} {perimetro:#.##} <br/>");

                    totalArea += area;
                    totalPerimetro += perimetro;
                    totalFormas += count;
                }

                sb.Append("TOTAL:<br/>");
                sb.Append($"{totalFormas} {EtiquetaFormas} ");
                sb.Append($"{EtiquetaPerimetro} {totalPerimetro:#.##} ");
                sb.Append($"Area {totalArea:#.##}");
            }

            return sb.ToString();
        }
    }
}
