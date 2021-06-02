using System;
using System.Collections.Generic;
using System.Text;

namespace LabOP5
{
    public class Tree
    {
        public Node RootNode;

        private string math = "^+-*/";
        private string[] expr;

        public Tree(string expression)
        {
            string[] str = ReversePolishNotation.Execute(expression).Split(" ");
            RootNode = new Node(str[^2]);
            RootNode.data = str[^2];
            RootNode.CreateTree(str, str.Length - 3);
            expr = str;
        }

        public double Execute(ref Dictionary<string, double> variables)
        {
            return Convert.ToDouble(RootNode.Execute(ref variables));
        }
    }
}
