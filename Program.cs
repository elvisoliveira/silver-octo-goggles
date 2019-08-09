using System;
using System.IO;

namespace ConsoleApp
{
	internal static class Program
	{
		private static void Main(string[] args)
		{
			var xml = File.ReadAllText(@"D:\NFSE.xml");
			var xmlAsObject = xml.Deserialize<nfeProc>();
			var objectAsXml = xmlAsObject.Serialize<nfeProc>();
			Console.WriteLine(objectAsXml);
		}
	}	
}
