using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;
using static System.Int32;

namespace LabOP5
{
    public class Node
    {
        public string data;
        private string math = "^+-*/";
        List<Node> childrenList = new List<Node>();
        Dictionary<string, double> variables = new Dictionary<string, double>();

        public Node(string data)
        {
            this.data = data;
        }

        public int CreateTree(string[] str, int startPos)
        {
            int counter = 0;
            for (int i = startPos; i >= 0; i--)
            {
                counter++;
                if (counter <= 2)
                {
                    if (math.Contains(str[i]))
                    {
                        Node n = new Node(str[i]);
                        i = n.CreateTree(str, i - 1);
                        childrenList.Add(n);
                    }
                    else
                    {
                        Node n = new Node(str[i]);
                        childrenList.Add(n);
                    }
                }
                else
                {
                    return i + 1;
                }
            }

            return 0;
        }
        public string Execute(ref Dictionary<string, double> vars)
        {
            variables = vars;
            if (childrenList.Count == 0)
                return data;
            switch (data)
            {
                case "=":
                    variables[childrenList[1].Execute(ref variables)] = ReturnExactNumber(childrenList[0].Execute(ref variables));
                    return null;
                case "+":
                    return Convert.ToString(ExactNumber(0) + ExactNumber(1));
                case "-":
                    return Convert.ToString(ExactNumber(0) - ExactNumber(1));
                case "*":
                    return Convert.ToString(ExactNumber(0) * ExactNumber(1));
                case "/":
                    return Convert.ToString(ExactNumber(0) / ExactNumber(1));
            }
            return "";
        }
        private double ExactNumber(int index)
        {
            return ReturnExactNumber(childrenList[index].Execute(ref variables));
        }
        private double ReturnExactNumber(string str)
        {
            int n = 0;
            if (TryParse(str, out n))
            {
                return n;
            }
            else
            {
                return variables[str];
            }
        }
    }
}
