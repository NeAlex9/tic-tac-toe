using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tick_tack_toe
{
    class Program
    {
        static bool CheckParameters(string[] parameters)
        {
            if ((parameters.Length & 1) == 0 || parameters.Length == 0 || parameters.Length == 1)
            {
                return false;
            }

            for (int i = 0; i < parameters.Length - 1; i++)
            {
                for (int j = i + 1; j < parameters.Length; j++)
                {
                    if (parameters[i] == parameters[j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        static void Main(string[] args)
        {
            string[] arr = {"s"};
            if (!CheckParameters(arr))
            {
                Console.WriteLine("invalid parameters");
                return;
            }

            var game = new tick_tack_toe(arr);
            game.StartGame();
        }
    }


}
