using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LabOP5
{
    public class Parser
    {
        StreamReader sr = new StreamReader("Program.txt");

        public double Execute()
        {
            double d = 0;
            Dictionary<string, double> variables = new Dictionary<string, double>();
            while (!sr.EndOfStream)
            {
                string expr = sr.ReadLine();
                Tree tree = new Tree(expr.Remove(expr.Length - 1));
                d = tree.Execute(ref variables);
            }
            return d;
        }
    }
}
