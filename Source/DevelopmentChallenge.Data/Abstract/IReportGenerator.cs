using System.Collections.Generic;

namespace DevelopmentChallenge.Data.Abstract
{
    public interface IReportGenerator
    {
        /// <summary>
        /// Genera un reporte a partir de una lista de formas geométricas.
        /// </summary>
        /// <param name="formas"></param>
        /// <returns></returns>
        string Generar(List<IFormaGeometrica> formas);
    }
}
