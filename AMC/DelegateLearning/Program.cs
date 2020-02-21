using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateLearning
{
    public class Program
    {
        public delegate void Operation(int a, int b);

        static void Main(string[] args)
        {
            var obj = new Program();
            var obj1 = new Operation(obj.Sum);
            var obj2 = new Operation(obj.Sub);
            ////
            obj1(10, 5);
            obj2(10, 5);

            Console.ReadKey();
        }
        public void Sum(int a, int b)
        {
            Console.WriteLine("(a + b) = {0}", a + b);
        }
        public void Sub(int a, int b)
        {
            Console.WriteLine("(a - b) = {0}", a - b);
        }
    }
}
