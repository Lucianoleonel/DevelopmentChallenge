# Development Challenge — Refactorización y Extensión de Formas Geométricas

## Descripción

Este proyecto genera reportes de formas geométricas en múltiples idiomas. La versión original contenía toda la lógica en una única clase con múltiples responsabilidades y estructuras `switch` que dificultaban la extensión. Se realizó una refactorización completa aplicando principios SOLID y patrones de diseño reconocidos.

---

## Cambios realizados

### 1. Separación de responsabilidades (Single Responsibility)

La clase `FormaGeometrica` original concentraba el cálculo de áreas, perímetros y generación de reportes en un único lugar. Se separó en clases independientes:

- `Cuadrado`, `Circulo`, `TrianguloEquilatero`, `Trapecio` — cada una responsable únicamente de sus cálculos geométricos.
- `ReportGeneratorCastellano`, `ReportGeneratorIngles`, `ReportGeneratorItaliano` — cada una responsable de la presentación en su idioma.
- `FormaGeometricaFactory`, `ReportGeneratorFactory` — responsables de la creación de instancias.

La clase `FormaGeometrica` se mantuvo por compatibilidad con la API existente, delegando internamente a las nuevas clases.

### 2. Interfaz `IFormaGeometrica`

Define el contrato que toda forma debe cumplir:

```csharp
public interface IFormaGeometrica
{
    int Tipo { get; }
    decimal CalcularArea();
    decimal CalcularPerimetro();
}
```

La propiedad `Tipo` permite que los generadores de reporte identifiquen y agrupen formas sin necesidad de hacer casting o type-checks explícitos (`OfType<>`).

### 3. Interfaz `IReportGenerator`

Contrato para los generadores de reporte:

```csharp
public interface IReportGenerator
{
    string Generar(List<IFormaGeometrica> formas);
}
```

`FormaGeometrica.Imprimir` depende de esta abstracción, no de implementaciones concretas (Dependency Inversion).

### 4. Clase abstracta `ReportGeneratorBase` — Template Method

Centraliza la lógica de generación del reporte usando el patrón **Template Method**: el método `Generar` define el esqueleto del algoritmo (encabezado → iterar formas agrupadas → footer), mientras que cada subclase aporta los textos en su idioma mediante propiedades abstractas y diccionarios de nombres.

El uso de `GroupBy(f => f.Tipo)` reemplaza los `OfType<Cuadrado>()`, `OfType<Circulo>()` hardcodeados del código original, haciendo que el generador sea completamente genérico.

**Beneficio concreto (Open/Closed):** agregar una nueva forma solo requiere una entrada en el diccionario del constructor de cada generador. No se modifica ningún método existente.

### 5. Factories — Factory Method

`FormaGeometricaFactory` y `ReportGeneratorFactory` encapsulan la creación de objetos. El resto del sistema trabaja contra interfaces, sin conocer las clases concretas instanciadas.

### 6. Nueva forma: `Trapecio`

Implementa `IFormaGeometrica` con constructor propio (`baseMayor`, `baseMenor`, `altura`). Calcula área y perímetro de trapecio isósceles correctamente.

Para mantener compatibilidad con la API legacy (que acepta un único `decimal`), la factory crea el trapecio con proporciones fijas: `baseMayor = lado`, `baseMenor = lado/2`, `altura = lado/2`.

### 7. Nuevo idioma: Italiano

`ReportGeneratorItaliano` extiende `ReportGeneratorBase` proveyendo los nombres en italiano (Quadrato, Cerchio, Triangolo, Trapezio) y los textos de encabezado y footer correspondientes. No fue necesario modificar ninguna clase existente.

### 8. Tests unitarios

Se mantienen los 5 tests originales sin modificaciones. Se agregaron 6 tests nuevos:

| Test | Descripción |
|------|-------------|
| `TestResumenListaConUnTrapecioEnCastellano` | Un trapecio, reporte en castellano |
| `TestResumenListaConDosTrapeciosEnIngles` | Dos trapecios, reporte en inglés |
| `TestResumenListaVaciaEnItaliano` | Lista vacía en italiano |
| `TestResumenListaConUnCuadradoEnItaliano` | Un cuadrado en italiano |
| `TestResumenListaConMasTiposEnItaliano` | Múltiples tipos incluyendo Trapecio en italiano |

**Resultado: 11/11 tests pasando.**

---

## Estructura final del proyecto

```
DevelopmentChallenge.Data/
├── Abstract/
│   ├── IFormaGeometrica.cs          — contrato de forma geométrica
│   ├── IReportGenerator.cs          — contrato de generador de reporte
│   ├── ReportGeneratorBase.cs       — lógica genérica (Template Method)
│   ├── ReportGeneratorCastellano.cs — reporte en español
│   ├── ReportGeneratorIngles.cs     — reporte en inglés
│   └── ReportGeneratorItaliano.cs   — reporte en italiano (nuevo)
├── Classes/
│   ├── FormaGeometrica.cs           — API legacy (compatibilidad)
│   ├── Cuadrado.cs
│   ├── Circulo.cs
│   ├── TrianguloEquilatero.cs
│   ├── Trapecio.cs                  — (nuevo)
│   └── Factories/
│       ├── FormaGeometricaFactory.cs
│       └── ReportGeneratorFactory.cs

DevelopmentChallenge.Shared/
└── StringHelperEspañol.cs           — strings y enums compartidos (Formas, Idiomas)
```

---

## Principios SOLID aplicados

| Principio | Aplicación |
|-----------|-----------|
| **S** — Single Responsibility | Cada clase tiene una única razón de cambio |
| **O** — Open/Closed | Agregar forma o idioma no modifica código existente |
| **L** — Liskov Substitution | Cualquier generador concreto reemplaza a `ReportGeneratorBase` sin afectar a `Imprimir` |
| **D** — Dependency Inversion | `FormaGeometrica.Imprimir` depende de `IReportGenerator`, no de clases concretas |
