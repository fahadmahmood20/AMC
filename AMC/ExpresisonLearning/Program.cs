using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpresisonLearning
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            var game = new VariableCaptureGame();

            int gameInput = 5;
            game.Run(gameInput);

            int jTry = 10;
            bool result = game.isEqualToCapturedLocalVariable(jTry);
            Console.WriteLine($"Captured local variable is equal to {jTry}: {result}");

            int anotherJ = 3;
            game.updateCapturedLocalVariable(anotherJ);

            bool equalToAnother = game.isEqualToCapturedLocalVariable(anotherJ);
            Console.WriteLine($"Another lambda observes a new value of captured variable: {equalToAnother}");
            Console.ReadKey();
        }
    }
}
