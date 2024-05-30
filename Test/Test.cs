using System.Xml.Linq;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace QuizGen.Tests
{
    public class Test
    {
        public List<Pregunta> Preguntas { get; init; }

        private string ToYAML()
        {
            var yaml = new SerializerBuilder()
                .WithNamingConvention(
                    new CamelCaseNamingConvention())
                .Build();
            return yaml.Serialize(this);
        }

        public override string ToString() => ToYAML();

        public static Test FromYAML(string yaml)
        {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(
                    new CamelCaseNamingConvention())
                .Build();
            return deserializer.Deserialize<Test>(yaml);
        }

        public XElement ToXML(string nombreFichero = "general")
        {
            var instrucciones = @"
            <p>Cada pregunta puede tener <b>una o más</b> de una respuestas correctas</p>.
            <p>La puntuación de cada pregunta se divide entre el número de respuestas correctas</p>.
            <p>Cada respuesta incorrecta resta también en proporción al número de posibilidades incorrectas</p>.
            <p>Tiene dos intentos para realizar la prueba y la calificación final será la media de ambos</p>.
            <p>Una vez finalice el plazo para realizar la prueba, podrá ver aquellos casos donde ha fallado y no podrá volver a realizarla</p>.
            ";

            var xml = new XElement("quiz",
                new XElement("question",
                    new XAttribute("type", "category"),
                    new XElement("category",
                        new XElement("text", $"$course$/top/{Categoria}")
                    )
                ),
                new XElement("question",
                    new XAttribute("type", "description"),
                    new XElement("name",
                        new XElement("text", "Instrucciones de la prueba")
                    ),
                    new XElement("questiontext",
                        new XAttribute("format", "html"),
                        new XElement("text",
                            new XCData(instrucciones)
                        )
                    ),
                    new XElement("defaultgrade", "0.0000000"),
                    new XElement("penalty", "0.0000000"),
                    new XElement("hidden", "0")
                )
            );
            double puntucionPorDefecto = 10D / Preguntas.Count;
            Preguntas.ForEach(
                pregunta => xml.Add(pregunta.ToXML(puntucionPorDefecto))
            );
            return xml;
        }
    }
}
