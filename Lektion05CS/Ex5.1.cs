using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lektion05CS
{
    class Ex51
    {
        public static void Main(string[] args)
        {
            var ints = new List<int>();
            ints.AddRange(1, 2, 3, 4, 5, -4, 6,-66, 7, 8, 9, 20, 55, 453, 20, 154);
            //Ex1(ints);
            //Ex2(ints);
        }

        public static void Ex1(List<int> ints)
        {
            int last = 0;
            int indexLast = 0;

            ints.ForEach(i =>
            {
                if (i > 15)
                {
                    last = i;
                    indexLast = ints.FindIndex(indexLast, l => (l == last));
                }
                if (i % 2 == 0) Console.WriteLine(i);
            });
            Console.WriteLine("last: " + last);
            Console.WriteLine("indexlast: " + indexLast);
        }
        public static void Ex2(List<int> ints)
        {
            var predEven = new Predicate<int>(isEven);
            var predTwos = new Predicate<int>(isTwoLong);

            var evens = ints.FindAll(predEven);
            var twos = ints.FindAll(predTwos);

            bool isEven(int i)
            {
                return i % 2 == 0;
            }
            bool isTwoLong(int i)
            {
                if (i < 0) return i.ToString().Substring(1).Length == 2;
                return i.ToString().Length == 2;
            }
            Console.WriteLine("printing evens");
            evens.ForEach(i => Console.WriteLine(i));
            Console.WriteLine("printing twos");
            twos.ForEach(i => Console.WriteLine(i));

        }
    }
}
