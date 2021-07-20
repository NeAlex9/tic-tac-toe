using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Numerics;

namespace tick_tack_toe
{
    public class tick_tack_toe
    {
        public bool CheckParameters(string[] parameters)
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

        
    }
}
