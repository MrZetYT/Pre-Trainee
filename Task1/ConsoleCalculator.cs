using System;

namespace Task1
{
    public class Calculator
    {
        private static readonly char[] operationsArray = ['+', '-', '*', '/'];
        public static bool IsCorrectInput(string input, ref int number)
        {
            try
            {
                number = int.Parse(input);
            }
            catch
            {
                Console.WriteLine("Неправильное число. Попробуйте ещё раз!");
                return false;
            }
            return true;
        }
        public static bool IsCorrectInput(string input, ref char operation)
        {
            try
            {
                operation = char.Parse(input);
            }
            catch
            {
                Console.WriteLine("Неправильная операция. Попробуйте ещё раз!");
                return false;
            }
            return true;
        }
        public static bool IsCorrectInput(string input, ref byte choice)
        {
            try
            {
                choice = byte.Parse(input);
            }
            catch
            {
                Console.WriteLine("Неправильный ввод. Попробуйте ещё раз!");
                return false;
            }
            return true;
        }
        static int ReadNumber(string message)
        {
            int number = 0;
            while (true)
            {
                Console.Write(message);
                if(IsCorrectInput(Console.ReadLine() ?? "", ref number)) return number;
            }
        }
        static char ReadOperation()
        {
            char operation= ' ';
            while (true)
            {
                Console.Write("1. Сложение - \"+\"\n" +
                    "2. Вычитение - \"-\"\n" +
                    "3. Умножение - \"*\"\n" +
                    "4. Деление - \"/\"\n" +
                    "Введите операцию: ");
                if (!IsCorrectInput(Console.ReadLine() ?? "", ref operation)) continue;
                if (!operationsArray.Contains(operation))
                {
                    Console.WriteLine("Неправильный символ операции. Попробуйте ещё раз!");
                    continue;
                }
                return operation;
            }
        }
        static double Calculate(int firstNum, int secondNum, char op)
        {
            return op switch
            {
                '+' => firstNum + secondNum,
                '-' => firstNum - secondNum,
                '*' => firstNum * secondNum,
                '/' => (double)firstNum / secondNum,
                _ => throw new InvalidOperationException("Неправильная операция!")
            };
        }
        public static void Main()
        {
            int firstNumber, secondNumber;
            char operation;
            byte userChoice = 0;
            double result;
            while (userChoice != 2)
            {
                firstNumber = ReadNumber("Введите первое число: ");

                operation = ReadOperation();

                secondNumber = ReadNumber("Введите второе число: ");

                if(secondNumber == 0 && operation == '/')
                {
                    Console.WriteLine("Деление на ноль невозможно!");
                    continue;
                }

                result = Calculate(firstNumber, secondNumber, operation);
                Console.WriteLine("Результат: {0}", result);

                while (true)
                {
                    Console.Write("1. Продолжить\n" +
                        "2. Выход\n" +
                        "Выбор: ");
                    if (!IsCorrectInput(Console.ReadLine() ?? "", ref userChoice))
                        continue;

                    if (userChoice == 1 || userChoice == 2)
                        break;

                    Console.WriteLine("Неверный выбор! Введите 1 или 2");
                }
            }
        }
    }
}