using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exercise
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 1: создать программу, где будет реализовано 3 потока. Каждый из\r\n" +
                "потоков будет выводить на экран числа от 1 до 10. Продемонстрировать.");
            Thread thread1 = new Thread(new ThreadStart(PrintNumbers));
            Thread thread2 = new Thread(new ThreadStart(PrintNumbers));
            Thread thread3 = new Thread(new ThreadStart(PrintNumbers));
            thread1.Start();
            thread2.Start();
            thread3.Start();

            Console.WriteLine("Все потоки завершены");
            Console.WriteLine("Нажмите Enter");
            Console.ReadKey();

            Console.WriteLine("Задание 2: создать программу, которая будет вычислять факториал от введенного\r\n" +
                "числа и квадрат от введенного числа.");
            Console.WriteLine("Введите число:");
            if(!int.TryParse(Console.ReadLine(), out int number))
            {
                Console.WriteLine("Неправильное значение");
                return;
            }
            Task<long> factorialTask = FactorialAsync(number);
            factorialTask.Wait();
            Console.WriteLine($"Факториал числа {number} равен {factorialTask.Result}");
            Console.WriteLine($"Квадрат числа {number} равен {Square(number)}");

            Console.WriteLine("Нажмите Enter");
            Console.ReadKey();

            Console.WriteLine("Задание 3: Вы получаете объект и должны вернуть имена всех(!) методов, которые вы нашли\r\n" +
                "для этого объекта.");
            Refl refl = new Refl();
            MethodInfo[] methods = refl.GetType().GetMethods();
            foreach (MethodInfo method in methods)
            {
                Console.WriteLine(method.Name);
            }
            Console.WriteLine("Нажмите Enter");
            Console.ReadKey();
        }

        static void PrintNumbers()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i);
            }
        }
        public static int Square(int number)
        {
            return number * number;
        }

        static async Task<long> FactorialAsync(int number)
        {
            await Task.Delay(8000);
            long factorial = 1;
            for (int i = 2; i <= number; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
    }
}
