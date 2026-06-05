using DevelopmentChallenge.Data.Abstract;
using DevelopmentChallenge.Shared;

namespace DevelopmentChallenge.Data.Classes.Factories
{
    public class ReportGeneratorFactory
    {

        /// <summary>
        /// Crea una instancia de IReportGenerator según el idioma seleccionado.
        /// </summary>
        /// <param name="idioma"></param>
        /// <returns></returns>
        public static IReportGenerator Crear(EnumsHelper.Idiomas idioma)
        {
            switch (idioma)
            {
                case EnumsHelper.Idiomas.Castellano:
                    return new ReportGeneratorCastellano();
                case EnumsHelper.Idiomas.Ingles:
                    return new ReportGeneratorIngles();
                case EnumsHelper.Idiomas.Italiano:
                    return new ReportGeneratorItaliano();
                default:
                    return new ReportGeneratorIngles();
            }
        }

    }
}
