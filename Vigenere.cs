using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class Vigenere
    {
        List<Result_Hamming> results = new List<Result_Hamming>();
        public List<Result_Hamming> Get_Lenght_Key()
        {
            return results;
        }

        public void Distance(byte[] bytearr)
        {

        }
        public static Dictionary<byte, int> GetByteFrequency(List<byte> bytearr)
        {
            // приймає список байтів - закодованих одним символом ключа
            // повертає символ і частоту з якою він зустрічається у тексті
            var fr = bytearr.GroupBy(c => c)
                        .Select(g => new { Symbol = g.Key, Count = g.Count() })
                        .OrderByDescending(b => b.Count)
                        .ToDictionary(c => c.Symbol, c => c.Count);
            // список відсортований - перше значення зустрічається найчастіше
            return fr;
        }
        public static byte DecodeRepeatingXOR(List<byte> bytearr) 
        {
            return 21;
        }

        public string GetKey(byte[] task2, int keyLength) 
        {
            return " ";
        }

        public string Decrypt(string keyLength, string input)
        {
            var result = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                result.Append((char)(input[i] ^ keyLength[i % keyLength.Length]));
            }
            return result.ToString();
        }


    }
}
