using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Day_14
{
    class Program
    {
        delegate T Operation<T, K, O>(O val1, K val2);

        static T Plus<T>(T val1, T val2)
        {
            return (dynamic)val1 + (dynamic)val2;
        }

        static T Minus<T>(T val1, T val2)
        {
            return (dynamic)val1 - (dynamic)val2;
        }

        static T Multiplication<T>(T val1, T val2)
        {
            return (dynamic)val1 * (dynamic)val2;
        }

        static T Division<T>(T val1, T val2)
        {
            if((dynamic)val2 == 0)
                throw new DivideByZeroException();
            else
                return (dynamic)val1 / (dynamic)val2;
        }
        static void Main(string[] args)
        {
            List<string> operands = new List<string>(); // Числа для проведения операций разделенные символом '|'
            List<char> operators = new List<char>(); // Операторы введеные пользователем
            Operation<double, double, double>[] operations = new Operation<double, double, double>[]{};
            Console.WriteLine("Вас приветствует калькулятор.\n\tИспользование: вводите первое число, затем введите (+, -, /, *), а после введите воторое число, после нажатия клавиши Enter вы можете повторить операцию, для вывода ответов операций введите: Вывод.");
            Console.WriteLine($"\n{new string('-', 35)}\n");
            string cmd = string.Empty;
            int arraySize = 0;
            while(cmd != "Вывод")
            {
                cmd = Console.ReadLine();
                if(cmd != "Вывод")
                {
                    Regex _regex = new Regex(@"^(?<oper1>\d+)(?<symb>.)(?<oper2>\d+)"); // Использование регулярных выражений для разделения строки введенной пользователем на числа и символ оператора
                    double A = 0.0; //Первый операнд
                    double B = 0.0; //Второй операнд
                    char operatorChr = '-'; //Символ оператора
                    foreach(Match _m in _regex.Matches(cmd))
                    {
                        A = double.Parse(_m.Groups["oper1"].ToString().Replace('.', ','));
                        B = double.Parse(_m.Groups["oper2"].ToString().Replace('.', ','));
                        operatorChr = Convert.ToChar(_m.Groups["symb"].ToString());
                        if(operatorChr == '+')
                        {
                            arraySize++;
                            Array.Resize(ref operations, arraySize);
                            operations[operations.Length - 1] = new Operation<double, double, double> (Plus);
                        }
                        else if(operatorChr == '-')
                        {
                            arraySize++;
                            Array.Resize(ref operations, arraySize);
                            operations[operations.Length - 1] = new Operation<double, double, double> (Minus);
                        }
                        else if(operatorChr == '/')
                        {
                            arraySize++;
                            Array.Resize(ref operations, arraySize);
                            operations[operations.Length - 1] = new Operation<double, double, double> (Division);
                        }
                        else if(operatorChr == '*')
                        {
                            arraySize++;
                            Array.Resize(ref operations, arraySize);
                            operations[operations.Length - 1] = new Operation<double, double, double> (Multiplication);
                        }
                    }
                    string operandsStr = string.Join('|', A ,B);
                    operands.Add(operandsStr);
                    operators.Add(operatorChr);
                }
            }

            if(cmd == "Вывод")
            {
                Console.WriteLine($"\n{new string('-', 35)}\n");
                if(operands != null)
                {
                    for(int i = 0; i < operands.Count - 1; i++)
                    {
                        string[] opers = operands[i].Split('|'); // Перевожу числа в массив, что бы перевести их в числовые переменные
                        double A = double.Parse(opers[0].Replace('.', ',')); // Первый левый операнд
                        double B = double.Parse(opers[1].Replace('.', ',')); // Второй правый операнд
                        Console.WriteLine($"{A} {operators[i]} {B} = {operations[i](A, B)}"); // Вывод данных в консоль
                    }
                }
            }
        }
    }
}
