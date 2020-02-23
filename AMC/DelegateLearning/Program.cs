using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DelegateLearning
{
    public class Program
    {
        public delegate void Operation(int a, int b);

        static void Main(string[] args)
        {
            ////ParameterExpression source = Expression.Parameter(typeof(string));
            ////string ValToCheck = "A";
            ////StringComparison StrComp = StringComparison.CurrentCultureIgnoreCase;

            ////MethodInfo miContain = typeof(StringExts).GetMethod("NewContains", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
            ////var bEXP = Expression.Call(miContain, source, Expression.Constant(ValToCheck), Expression.Constant(StrComp));

            ////var lambda = Expression.Lambda<Func<string, bool>>(bEXP, source);

            ////bool b = lambda.Compile().Invoke("a");



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
