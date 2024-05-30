

using System.Globalization;
using System.Xml.Linq;

namespace QuizGen.Tests
{
    public class Respuesta
    {
        public string Texto { get; init; }
        public bool Correcta { get; init; }

        public XElement ToXML(
            double porcentajeCorrecta = 100,
            double porcentajeIncorrecta = 0
        )
        {
            double calificación = Correcta ? porcentajeCorrecta : porcentajeIncorrecta;
            return new XElement("answer",
                new XAttribute("fraction", calificación.ToString("F3", CultureInfo.InvariantCulture)),
                new XAttribute("format", "html"),
                new XElement("text",
                    new XCData($"<p>{Texto}</p>")
                )
            );
        }
    }
}
