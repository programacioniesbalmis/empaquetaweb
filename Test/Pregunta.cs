using System.Xml.Linq;

namespace QuizGen.Tests
{
    public class Pregunta
    {
        public string Enunciado { get; init; }
        public List<Respuesta> Respuestas { get; init; }
        public XElement ToXML()
        {
            string answernumbering = Respuestas.Aggregate(
                new { Cont = 1, Text = "1" },
                (acc, _) => new { Cont = acc.Cont + 1, Text = acc.Text + (acc.Cont + 1) }
            ).Text;
            var xml = new XElement(
                "question",
                new XAttribute("type", "multichoice"),
                new XElement("name",
                    new XElement("text", "")
                ),
                new XElement("questiontext",
                    new XAttribute("format", "html"),
                    new XElement("text",
                        new XCData(Enunciado)
                    )
                ),
                new XElement("defaultgrade", "1.0000000"),
                new XElement("penalty", "0.0000000"),
                new XElement("hidden", "0"),
                new XElement("single", "false"),
                new XElement("shuffleanswers", "true"),
                new XElement("answernumbering", answernumbering),
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

            Respuestas.ForEach(
                respuesta => xml.Add(respuesta.ToXML())
            );

            return xml;
        }
    }
}
