using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class CaesarAlgorithm
    {
        string[] output = new string[255];
        string Input;

        public CaesarAlgorithm(string input)
        {
            this.Input = input;

        }

        public string getDecrypt()
        {
            for (int i = 0; i < 255; i++)
            {
                output[i] = DecryptXOR(i, Input);
            }

            double Max = 0;
            int key = 0;
            for (int i = 0; i < output.Length; i++)
            {
                // if (i < 70) { Console.WriteLine(i + "  " + outputs[i]); Console.WriteLine(); }

                var partoftext = Utilites.PartOfText(output[i]);

                if (partoftext > Max)
                {
                    key = i;
                    Max = partoftext;
                }
            }

            Console.WriteLine(key);

            return output[key];
        }

        public static string DecryptXOR(int key, string input)
        {
            return new string(input.ToCharArray().Select(c => (char)(c ^ key)).ToArray());

        }
    }
}
