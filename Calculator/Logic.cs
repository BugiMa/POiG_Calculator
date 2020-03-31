using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class Logic
    {
        #region Prop
        private string[] operators = { "+", "-", "*", "/", "=" };
        private string lastAction = "";
        private string lastOperator = "*";
        private double result = 1;
        public string Equation { get; set; } = "";
        public string Display { get; set; } = "0";
        #endregion
        #region Methods
        public void Number(string number)
        {
            if (lastAction == "=" || lastAction == "exc")
            {
                ClearAll();
            }
            else if (operators.Contains(lastAction) && lastAction != "+-")
                Clear();
            Display = Display != "0" && Display != "-0" ? Display + number : Display.Remove(Display.Length - 1) + number;
            lastAction = number;
        }
        public void Operation(string operation)
        {
            if (double.TryParse(Display, out double val))
            {
                if (val == 0)
                    Display = "0";
                if (!(lastOperator == "/" && Display == "0"))
                {
                    if (lastAction != "+-")
                    {
                        if (operators.Contains(lastAction) && lastAction != "=")
                            Equation = Equation.Remove(Equation.Length - 1) + operation;
                        else if (lastAction != "exc")
                        {
                            if (lastAction == "=")
                                Equation = "";
                            Equation += Display;

                            Math(lastOperator, val);
                            Display = result.ToString();

                            Equation += operation;
                        }
                        lastAction = operation;
                        lastOperator = operation;
                    }
                }
                else
                {
                    ClearAll();
                    Equation = "Cant divide by zero!";
                    lastAction = "exc";
                }
            }
        }
        public void Math(string operation, double val)
        {
            switch (operation)
            {
                case "+":
                    result += val;
                    break;
                case "-":
                    result -= val;
                    break;
                case "*":
                    result *= val;
                    break;
                case "/":
                    result /= val;
                    break;
            }
        } 
        public void Clear()
        {
            Display = "0";
        }
        public void ClearAll()
        {
            Clear();
            result = 1;
            Equation = "";
            lastOperator = "*";
        }
        public void Coma()
        {
            if (!operators.Contains(lastAction))
                if (!Display.Contains(","))
                    Display += ",";
        }
        public void PlusMinus()
        {
            if (operators.Contains(lastAction))
                Clear();
            if (!Display.Contains("-"))
                Display = Display.Insert(0, "-");
            else
                Display = Display.Substring(1, Display.Length - 1);
            lastAction = "+-";
        }
        #endregion
    }
}
