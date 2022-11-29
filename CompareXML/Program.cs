using Microsoft.XmlDiffPatch;
using System;
using System.IO;
using System.Xml;

namespace CompareXML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstXml = File.ReadAllText("C:/Users/LENOVO/Desktop/Study/CompareXML/CompareXML/XMLFile1.xml");
            string secondXml = File.ReadAllText("C:/Users/LENOVO/Desktop/Study/CompareXML/CompareXML/XMLFile2.xml");

            var result = GenerateDiffGram(firstXml, secondXml);
            File.WriteAllText("C:/Users/LENOVO/Desktop/Study/CompareXML/CompareXML/change.xml", result);
            Console.WriteLine("Hello World!");
        }

        public static string GenerateDiffGram(string originalFile, string finalFile)
        {
            var xmldiff = new XmlDiff();
            var r1 = XmlReader.Create(new StringReader(originalFile));
            var r2 = XmlReader.Create(new StringReader(finalFile));
            var sw = new StringWriter();
            var xw = new XmlTextWriter(sw) { Formatting = Formatting.Indented };
            bool bIdentical = xmldiff.Compare(r1, r2, xw);
            Console.WriteLine();
            Console.WriteLine("bIdentical: " + bIdentical);

            return sw.ToString();
        }
    }
}
