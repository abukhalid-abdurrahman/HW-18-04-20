using System;
using System.Collections.Generic;

namespace Day_14
{
    delegate T Operation<T, K, O>(O val1, K val2);
    class Program
    {
        static void Main(string[] args)
        {
            List<string> operands = new List<string>(); // Числа для проведения операций разделенные символом '|'
            List<char> operators = new List<char>(); // Операторы введеные пользователем
            Operation<double, double, double> operation = null;
            Console.WriteLine("Вас приветствует калькулятор.\n\tИспользование: вводите первое число, затем введите (+, -, /, *), а после введите воторое число, после нажатия клавиши Enter вы можете повторить операцию, для вывода ответов операций введите: Вывод.");
            
            string cmd = string.Empty;
            while(cmd != "Вывод")
            {

            }

            if(cmd == "Вывод")
            {
                if(operands != null)
                {
                    for(int i = 0; i < operands.Count - 1; i++)
                    {
                        string[] opers = operands[i].Split('|'); // Перевожу числа в массив, что бы перевести их в числовые переменные
                        double A = double.Parse(opers[0].Replace('.', ',')); // Первый левый операнд
                        double B = double.Parse(opers[1].Replace('.', ',')); // Второй правый операнд
                        Console.WriteLine($"{A} {operators[i]} {B} = {operation(A, B)}"); // Вывод данных в консоль
                    }
                }
            }
        }
    }
}
