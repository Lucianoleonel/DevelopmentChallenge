using System;
using System.Collections.Generic;
using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Shared;
using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            string result = string.Format(StringHelperTags.TagH1, StringHelperEspañol.ListaVacíaDeFormas);
            //Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
            Assert.AreEqual(result,
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), EnumsHelper.Idiomas.Castellano));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            string result = string.Format(StringHelperTags.TagH1, StringHelperIngles.EmptyListOfShapes);
            Assert.AreEqual(result,
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), EnumsHelper.Idiomas.Ingles));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            List<FormaGeometrica> cuadrados = new List<FormaGeometrica> {new FormaGeometrica(EnumsHelper.Formas.Cuadrado, 5)};

            string resumen = FormaGeometrica.Imprimir(cuadrados, EnumsHelper.Idiomas.Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            List<FormaGeometrica> cuadrados = new List<FormaGeometrica>
            {
                new FormaGeometrica(EnumsHelper.Formas.Cuadrado, 5),
                new FormaGeometrica(EnumsHelper.Formas.Cuadrado, 1),
                new FormaGeometrica(EnumsHelper.Formas.Cuadrado, 3)
            };

            string resumen = FormaGeometrica.Imprimir(cuadrados, EnumsHelper.Idiomas.Ingles);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            List<FormaGeometrica> formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(EnumsHelper.Formas.Cuadrado, 5),
                new FormaGeometrica(EnumsHelper.Formas.Circulo, 3),
                new FormaGeometrica(EnumsHelper.Formas.TrianguloEquilatero, 4),
                new FormaGeometrica(EnumsHelper.Formas.Cuadrado, 2),
                new FormaGeometrica(EnumsHelper.Formas.TrianguloEquilatero, 9),
                new FormaGeometrica(EnumsHelper.Formas.Circulo, 2.75m),
                new FormaGeometrica(EnumsHelper.Formas.TrianguloEquilatero, 4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, EnumsHelper.Idiomas.Ingles);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            List<FormaGeometrica> formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(EnumsHelper.Formas.Cuadrado, 5),
                new FormaGeometrica(EnumsHelper.Formas.Circulo, 3),
                new FormaGeometrica(EnumsHelper.Formas.TrianguloEquilatero, 4),
                new FormaGeometrica(EnumsHelper.Formas.Cuadrado, 2),
                new FormaGeometrica(EnumsHelper.Formas.TrianguloEquilatero, 9),
                new FormaGeometrica(EnumsHelper.Formas.Circulo, 2.75m),
                new FormaGeometrica(EnumsHelper.Formas.TrianguloEquilatero, 4.2m)
            };

            string resumen = FormaGeometrica.Imprimir(formas, EnumsHelper.Idiomas.Castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
                resumen);
        }

        #region Tests de Trapecio

        
        // --- Tests de Trapecio ---
        // FormaGeometrica(Trapecio, 4) crea Trapecio(baseMayor=4, baseMenor=2, altura=2)
        // Area = (4+2)/2 * 2 = 6 | Perimetro = 4+2+2*sqrt(1²+2²) = 6+2*sqrt(5) ≈ 10,47

        [TestCase]
        public void TestResumenListaConUnTrapecioEnCastellano()
        {
            List<FormaGeometrica> formas = new List<FormaGeometrica> { new FormaGeometrica(EnumsHelper.Formas.Trapecio, 4) };

            string resumen = FormaGeometrica.Imprimir(formas, EnumsHelper.Idiomas.Castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>1 Trapecio | Area 6 | Perimetro 10,47 <br/>TOTAL:<br/>1 formas Perimetro 10,47 Area 6",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConDosTrapeciosEnIngles()
        {
            List<FormaGeometrica> formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(EnumsHelper.Formas.Trapecio, 4),
                new FormaGeometrica(EnumsHelper.Formas.Trapecio, 4)
            };

            string resumen = FormaGeometrica.Imprimir(formas, EnumsHelper.Idiomas.Ingles);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Trapezoids | Area 12 | Perimeter 20,94 <br/>TOTAL:<br/>2 shapes Perimeter 20,94 Area 12",
                resumen);
        }
        #endregion

        #region Tets de Italiano

        [TestCase]
        public void TestResumenListaVaciaEnItaliano()
        {
            Assert.AreEqual("<h1>Lista vuota di forme!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), EnumsHelper.Idiomas.Italiano));
        }

        [TestCase]
        public void TestResumenListaConUnCuadradoEnItaliano()
        {
            List<FormaGeometrica> formas = new List<FormaGeometrica> { new FormaGeometrica(EnumsHelper.Formas.Cuadrado, 5) };

            string resumen = FormaGeometrica.Imprimir(formas, EnumsHelper.Idiomas.Italiano);

            Assert.AreEqual(
                "<h1>Rapporto sulle forme</h1>1 Quadrato | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 forme Perimetro 20 Area 25",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnItaliano()
        {
            List<FormaGeometrica> formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(EnumsHelper.Formas.Cuadrado, 5),
                new FormaGeometrica(EnumsHelper.Formas.Circulo, 3),
                new FormaGeometrica(EnumsHelper.Formas.TrianguloEquilatero, 4),
                new FormaGeometrica(EnumsHelper.Formas.Trapecio, 4)
            };

            string resumen = FormaGeometrica.Imprimir(formas, EnumsHelper.Idiomas.Italiano);

            Assert.AreEqual(
                "<h1>Rapporto sulle forme</h1>1 Quadrato | Area 25 | Perimetro 20 <br/>1 Cerchio | Area 7,07 | Perimetro 9,42 <br/>1 Triangolo | Area 6,93 | Perimetro 12 <br/>1 Trapezio | Area 6 | Perimetro 10,47 <br/>TOTAL:<br/>4 forme Perimetro 51,9 Area 45",
                resumen);
        }
        #endregion
    }
}
