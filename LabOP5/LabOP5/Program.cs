using System;

namespace LabOP5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter file path:");
            string path = Console.ReadLine();
            Parser prs = new Parser(path);
            Console.WriteLine(prs.Execute());
        }
    }
}
