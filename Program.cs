using System;

namespace Day_14
{
    delegate T Operation<T, K, O>(O val1, K val2);
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует калькулятор.\n\tИспользование: вводите первое число, затем введите (+, -, /, *), а после введите воторое число, после нажатия клавиши Enter вы можете повторить операцию, для вывода ответов операций введите: Вывод.");
            
            string cmd = string.Empty;
            while(cmd != "Вывод")
            {

            }

            if(cmd == "Вывод")
            {

            }
        }
    }
}
