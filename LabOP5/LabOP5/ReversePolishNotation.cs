using System;
using System.Collections.Generic;
using System.Text;

namespace LabOP5
{
    public static  class ReversePolishNotation
    {
        private static string math = "=+-*/()";
        public static string Execute(string str)
        {
            Stack<string> maStack = new Stack<string>();
            string output = "";
            str.Remove(str.Length - 1);
            for (int i = 0; i < str.Length; i++)
            {
                if (!math.Contains(str[i]))
                {
                    if (str[i].ToString() != " ")
                        if (i + 1 < str.Length && str[i + 1].ToString() != " " && !math.Contains(str[i+1]))
                            output += str[i];
                        else
                            output += str[i] + " ";

                }
                else
                {
                    if (str[i].ToString() == ")")
                    {
                        while (maStack.Peek() != "(")
                        {
                            output += maStack.Pop() + " ";
                        }

                        maStack.Pop();
                    }
                    else
                    {
                        maStack.Push(str[i].ToString());
                    }
                }
            }

            while (maStack.Count!=0)
            {
                output += maStack.Pop() + " ";
            }
            return output;
        }

    }
}
