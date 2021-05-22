using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;
using static System.Int32;

namespace LabOP5
{
    class Node
    {
        public string data;
        List<Node> childremList = new List<Node>();
        Dictionary<string, int> variables = new Dictionary<string, int>();

        public string Execute(ref Dictionary<string, int> vars)
        {
            variables = vars;
            if (childremList.Count == 0)
                return data;
            switch (data)
            {
                case "=":
                    variables[childremList[1].Execute(ref variables)] = ReturnExactNumber(childremList[0].Execute(ref variables));
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
        private int ExactNumber(int index)
        {
            return ReturnExactNumber(childremList[index].Execute(ref variables));
        }
        private int ReturnExactNumber(string str)
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
