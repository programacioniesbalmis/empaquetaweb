using System.Text;
using QuizGen.Tests;

class Program
{
    private static void Main()
    {
        using StreamReader sR = new StreamReader(
            "encuesta_inicial_pmdm.yaml", 
            Encoding.UTF8);
        string yaml = sR.ReadToEnd();
        
        Test test = Test.FromYAML(yaml);
        Console.WriteLine(test);

        using StreamWriter sW = new StreamWriter(
            "encuesta_inicial_pmdm.xml", 
            false, 
            Encoding.UTF8);
        sW.WriteLine(test.ToXML(Path.GetFileNameWithoutExtension("encuesta_inicial_pmdm.xml")));
    }
}

