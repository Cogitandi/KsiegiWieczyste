using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ksiegiwieczyste
{
    class Program
    {
        static void Main(string[] args)
        {
            var availableChars = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            var lista = VariationClass.GetVariations(availableChars, 6);

            int sum = 0;
            var builder = new StringBuilder();
           foreach(var item in lista)
            {
                var generatedIdentifier = String.Join("", item);
                if (Data.IsNumberValid("KR1C", generatedIdentifier,9))
                {
                    sum++;
                    var text = String.Join("", item);
                    builder.Append(text+"\n");
                    Console.WriteLine(String.Join("", item));
                    
                }
                
            }
            Console.WriteLine(sum);
            File.WriteAllText("plik.txt", builder.ToString());
        }


        public static void Test(Func<IList<int>, int, IEnumerable<IEnumerable<int>>> getVariations)
        {
            var max = 6;
            var timer = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 1; i < max; ++i)
                for (int j = 1; j < i; ++j)
                    getVariations(MakeList(i), j).Count();
            timer.Stop();
            Console.WriteLine("{0,40}{1} ms", getVariations.Method.Name, timer.ElapsedMilliseconds);
        }

        // Make a list that repeats to guarantee we have duplicates
        public static IList<int> MakeList(int size)
        {
            return Enumerable.Range(0, size / 2).Concat(Enumerable.Range(0, size - size / 2)).ToList();
        }



    }
}
