using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Variants
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Идёт рассчёт");
            CalculateVariants();
        }

        static void CalculateVariants()
        {
            var myReg = new Regex("\r\n");
            var reader = new StreamReader(@"C:\WORK WORK WORK\random_numbers.txt"); 
            var textStr = myReg.Replace(reader.ReadToEnd(), " ").Split(' ').ToList<string>();
            textStr.RemoveAll(x => x == "");
            var numbers = textStr.Select(x => int.Parse(x)).ToList<int>();
            numbers.Sort();
            var res = new List<int>();
            foreach (var num in numbers)
            {
                if (!res.Contains(num))
                {
                    res.Add(num);
                    Console.Write(".");
                }                
            }
            Console.WriteLine();
            Console.WriteLine("Обработка завершена");
            Console.WriteLine($"Всего значений: {res.Count}");
            Console.WriteLine("Значения вариант в порядке возрастания: ");
            foreach(var num in res)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
    }
}
