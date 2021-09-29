using System;
using System.Collections.Generic;
using System.Text;

namespace progetto_15_09_2021
{
    public static class StringUtils
    {
        public static string Reverse (string original) //Funzione inverti la stringa. Statica così non devo creare un oggetto per utilizzarla.
        {
            string result = "";
            for (int i = original.Length-1; i >= 0 ; i--)
            {
                char c = original[i];
                //result = result + c; //Concateno le stringhe 
                result += c;
            }
            return result;
        }
    }
}
