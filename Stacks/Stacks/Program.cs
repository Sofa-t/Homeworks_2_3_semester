using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Stacks
{
    class Program
    {
        static void Main(string[] args)
        {
            Input();
        }

        static void Input()
        {
            var myReg = new Regex(@"\r\n");
            var reader = new StreamReader(@"C:\Users\boxes.txt").ReadToEnd();
            var arrayStacks = myReg.Replace(reader,"!").Split('!').ToList<string>();
            arrayStacks.RemoveAt(arrayStacks.Count - 1);
            var arrayStacksInt = new List<Stack<int>>();          
            foreach (var str in arrayStacks)
            {
                var temp = new Stack<int>();
                var arr = str.Split(' ').Select(x => int.Parse(x)).ToList<int>();
                foreach(var num in arr)
                    temp.Push(num);
                arrayStacksInt.Add(temp);
            }
            Rearranging(arrayStacksInt);
        }

        static void Rearranging(List<Stack<int>> stacks)
        {
            var countStep = 0;
            var startMess = PrintRes(stacks, "Начальное расположение: \n\r");
            var fileRes = new FileStream(@"C:\Users\moves.txt", FileMode.Create);
            fileRes.Close();
            var writer = new StreamWriter(@"C:\Users\moves.txt");
            for (var i = 0; i < stacks.Count - 1; i++)
            {
                var stackCount = stacks[i].Count;
                for(var j = 0; j < stackCount; j++)
                {
                    var box = stacks[i].Pop();
                    stacks[stacks.Count - 1].Push(box);
                    WriteSteps(box, i + 1, stacks.Count, writer);
                    countStep++;
                }
            }
            var iterCount = stacks[stacks.Count - 1].Count; 
            for(var i = 0; i < iterCount; i++)
            {
                var box = stacks[stacks.Count - 1].Pop();
                if (box != stacks.Count)
                {
                    stacks[box - 1].Push(box);
                    WriteSteps(box, stacks.Count, box, writer);
                    countStep++;
                }
                else
                {
                    stacks[0].Push(box);
                    WriteSteps(box, stacks.Count, 1, writer);
                    countStep++;
                }
            }
            iterCount = stacks[0].Count;
            for(var i = 0; i < iterCount; i++)
            {
                var box = stacks[0].Pop();
                if (box == 1)
                {
                    stacks[1].Push(box);
                    WriteSteps(box, 1, 2, writer);
                    countStep++;
                }
                else
                {
                    stacks[stacks.Count - 1].Push(box);
                    WriteSteps(box, 1, stacks.Count - 1, writer);
                    countStep++;
                }
            }
            iterCount = stacks[1].Count;
            for(var i = 0; i < iterCount; i++)
            {
                var box = stacks[1].Pop();
                if (box == 2)
                    stacks[1].Push(box);
                else
                {
                    stacks[0].Push(box);
                    WriteSteps(box, 2, 1, writer);
                    countStep++;
                }
            }
            Console.WriteLine(startMess);
            Console.WriteLine($"Число перекладываний : {countStep}");
            Console.WriteLine();
            Console.WriteLine(PrintRes(stacks, "Конечное расположение:"));
        }

        static void WriteSteps(int box, int oldHeap, int newHeap, StreamWriter writer)
        {
            writer.WriteLine($"Переложить ящик {box} из {oldHeap} кучи в {newHeap} кучу");
        }

        static string PrintRes(List<Stack<int>> res, string mess)
        {
            var resStr = new StringBuilder(mess);
            for(var i = 0; i < res.Count; i++)
            {
                resStr.Append($"Стопка {i + 1}: ");
                foreach (var box in res[i])
                    resStr.Append(box + " ");
                resStr.Append("\n\r");
            }
            return resStr.ToString();
        }
    }
}
