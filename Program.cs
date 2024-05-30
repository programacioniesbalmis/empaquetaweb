using System.Text;
using QuizGen.Tests;

class Program
{
    private static void Main()
    {
        using StreamReader sR = new StreamReader(
            "B1-la_plataforma_dotnet.yaml", 
            Encoding.UTF8);
        string yaml = sR.ReadToEnd();
        
        Test test = Test.FromYAML(yaml);
        Console.WriteLine(test);

        using StreamWriter sW = new StreamWriter(
            "B1-la_plataforma_dotnet.xml", 
            false, 
            Encoding.UTF8);
        sW.WriteLine(test.ToXML());
    }
}

