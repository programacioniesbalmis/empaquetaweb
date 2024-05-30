using System.Xml.Linq;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace QuizGen.Tests
{
    public class Test
    {
        public string Categoria { get; init; }
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

        public XElement ToXML()
        {
            var xml = new XElement("quiz",
                new XElement("question",
                    new XAttribute("type", "category"),
                    new XElement("category",
                        new XElement("text", $"$course$/top/{Categoria}")
                    ),
                    new XElement("question",
                        new XAttribute("type", "description"),
                        new XElement("name",
                            new XElement("text", "Instrucciones de la prueba")
                        ),
                        new XElement("questiontext",
                            new XAttribute("format", "html"),
                            new XElement("text",
                                new XCData("Aquí van las instrucciones.")
                            )
                        ),
                        new XElement("defaultgrade", "0.0000000"),
                        new XElement("penalty", "0.0000000"),
                        new XElement("hidden", "0")
                    )
                )
            );

            Preguntas.ForEach(
                pregunta => xml.Add(pregunta.ToXML())
            );
            return xml;
        }
    }
}
