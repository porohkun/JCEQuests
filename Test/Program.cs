using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JCEQuests.Quests;
using PNetJson;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Calc(false, "2+-3*4");
            Console.ReadLine();

            Calc(true, "(-(2+3*4)>5)||!(6!=7)"); //6!=7 сравнение должно быть не только между булями, но и между числами.
            Console.ReadLine();

            Calc(false, "(!yes)?3:-4");
            Console.ReadLine();

            Calc(true, "(2==2)?(11>5):(22!=4)");
            Console.ReadLine();

            Calc(false, "no ? (false ? 3 : 4) : (true ? 6 : 7)");
            Console.ReadLine();
        }

        static void Calc(bool b, string sequence)
        {
            if (b)
                Console.WriteLine(string.Format("{0} = {1}", sequence, Condition.Create(sequence).Check(null)));
            else
                Console.WriteLine(string.Format("{0} = {1}", sequence, Condition.Create(sequence).Calculate(null)));
        }
    }
}
