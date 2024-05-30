

using System.Xml.Linq;

namespace QuizGen.Tests
{
    public class Respuesta
    {
        public string Texto { get; init; }
        public bool Correcta { get; init; }

        public XElement ToXML()
        {
            return new XElement("answer",
                new XAttribute("fraction", Correcta ? "100" : "0"),
                new XAttribute("format", "html"),
                new XElement("text",
                    new XCData(Texto)
                )
            );
        }
    }
}
