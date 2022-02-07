using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal static class MyContainer
    {
        // Static donc ne devrait pas être thread safe
        public static List<int> Ints { get; } = Enumerable.Range(1,4).ToList();

        public static async Task NotSafePrint()
        {
            for (var i = 0; i<Ints.Count(); i++)
            {
                Console.Write(Ints[i]+ " ");
                await Task.Delay(1);
            }
            Console.WriteLine("");
        }

        public static async Task NotSafeAdd(int i)
        {
            Ints.Add(i);
            await Task.Delay(100);
        }

    }
}
