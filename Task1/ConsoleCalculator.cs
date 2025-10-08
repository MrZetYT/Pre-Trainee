using System;

namespace Task1
{
    public class Calculator
    {
        private static readonly Dictionary<char, IOperation> Operations = new()
        {
            { '+', new AdditionOperation() },
            { '-', new SubtractionOperation() },
            { '*', new MultiplicationOperation() },
            { '/', new DivisionOperation() }
        };
        static double ReadNumber(string message)
        {
            while (true)
            {
                Console.Write(message);
                if (double.TryParse(Console.ReadLine(), out double number))
                    return number;

                Console.WriteLine("Неверное число. Попробуйте ещё раз!");
            }
        }
        static char ReadOperation()
        {
            while (true)
            {
                Console.Write("1. Сложение - \"+\"\n" +
                              "2. Вычитание - \"-\"\n" +
                              "3. Умножение - \"*\"\n" +
                              "4. Деление - \"/\"\n" +
                              "Введите операцию: ");

                if (char.TryParse(Console.ReadLine(), out char op) && Operations.ContainsKey(op))
                    return op;

                Console.WriteLine("Неверная операция. Попробуйте ещё раз!");
            }
        }
        public static void Main()
        {
            double firstNumber, secondNumber, result;
            char operation;
            byte choice = 0;

            while (choice != 2)
            {
                firstNumber = ReadNumber("Введите первое число: ");
                operation = ReadOperation();
                secondNumber = ReadNumber("Введите второе число: ");

                try
                {
                    IOperation selectedOp = Operations[operation];
                    result = selectedOp.Execute(firstNumber, secondNumber);
                    Console.WriteLine($"Результат: {result}");
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                while (true)
                {
                    Console.Write("1. Продолжить\n2. Выход\nВыбор: ");
                    if (byte.TryParse(Console.ReadLine(), out choice) && (choice == 1 || choice == 2))
                        break;

                    Console.WriteLine("Неверный выбор! Введите 1 или 2.");
                }
            }
        }
    }
}