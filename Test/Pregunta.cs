using System.Globalization;
using System.Xml.Linq;

namespace QuizGen.Tests
{
    public class Pregunta
    {
        public string Enunciado { get; init; }
        public List<Respuesta> Respuestas { get; init; }

        public XElement ToXML(double puntucionPorDefecto = 1.0D)
        {
            var xml = new XElement(
                "question",
                new XAttribute("type", "multichoice"),
                new XElement("name",
                    new XElement("text", "")
                ),
                new XElement("questiontext",
                    new XAttribute("format", "html"),
                    new XElement("text",
                        new XCData($"<h4>{Enunciado}</h4>")
                    )
                ),
                new XElement("defaultgrade", puntucionPorDefecto.ToString(CultureInfo.InvariantCulture)),
                new XElement("penalty", "0.0000000"),
                new XElement("hidden", "0"),
                new XElement("single", "false"),
                new XElement("shuffleanswers", "true"),
                new XElement("answernumbering", "abc"),
                new XElement("showstandardinstruction", "0"),
                new XElement("correctfeedback",
                    new XAttribute("format", "html"),
                    new XElement("text", "Respuesta correcta")
                ),
                new XElement("partiallycorrectfeedback",
                    new XAttribute("format", "html"),
                    new XElement("text", "Respuesta parcialmente correcta.")
                ),
                new XElement("incorrectfeedback",
                    new XAttribute("format", "html"),
                    new XElement("text", "Respuesta incorrecta.")
                ),
                new XElement("shownumcorrect")
            );

            int respuestasCorrectas = Respuestas.Count(respuesta => respuesta.Correcta);
            double porcentajeCorrecta = 100D / respuestasCorrectas;
            double porcentajeIncorrecta = -100D / (Respuestas.Count - respuestasCorrectas);

            Respuestas.ForEach(
                respuesta => xml.Add(respuesta.ToXML(
                    porcentajeCorrecta, porcentajeIncorrecta
                ))
            );

            return xml;
        }
    }
}
