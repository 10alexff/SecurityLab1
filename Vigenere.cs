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
            int maxKeySize = 20;
            int currKeySize = 2;

            while (currKeySize < maxKeySize)
            {
                Result_Hamming result = new Result_Hamming();
                int bytesCount = 0;
                var distancesList = new List<double>();
                for (int i = 0; i < bytearr.Length; i += currKeySize)
                {
                    if (i + (2 * currKeySize) > bytearr.Length)
                        continue;
                    var bytes1 = new List<byte>();// списки байтів зашифрованих символів
                    var bytes2 = new List<byte>(); // довжина списку = довжині ключа

                    for (int j = i; j < i + currKeySize; j++) // цикли = довжині ключа
                    {
                        bytes1.Add(bytearr[j]);
                    }
                    for (int n = i + currKeySize; n < i + (2 * currKeySize); n++) // наспуні кілька символів, теж довжина ключа
                    {
                        bytes2.Add(bytearr[n]);
                    }
                    distancesList.Add(Utilites.Hamming(bytes1, bytes2));
                    bytesCount++;
                }
                result.Key_Lenght = currKeySize;
                result.Distance1 = distancesList.Sum() / bytesCount; // середня відстань на байт
                result.Distance2 = (distancesList.Sum() / bytesCount) / currKeySize; // середня відстань в залежності від ключа
                results.Add(result);
                currKeySize++;
            }
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
            var topSymbols = bytearr.Take(5).ToList();
            var letters = new char[] { 'a', 'e', 'i', 'n', 'o' };
            var letterBytes = letters.Select(c => (byte)c).ToList();
            // беремо 5 найвживаніших символів
            var listCounts = new List<byte>();
            for (int i = 0; i < letterBytes.Count; i++)
            {
                for (int j = 0; j < topSymbols.Count; j++)
                {
                    var xor = letterBytes[i] ^ topSymbols[j];
                    listCounts.Add(Convert.ToByte(xor)); // список розкодаваних символів в байтах - можливі ключі
                }
            }
            var KeyLetters = GetByteFrequency(listCounts);

            return KeyLetters.First().Key; // повертаємо найчастіше вживане
        }

        public string GetKey(byte[] task2, int keyLength) 
        {
            char[] Sumbols = new char[keyLength];
            for (int i = 0; i < keyLength; i++)
            {
                var intel = GetByteFrequency(Utilites.division(task2.ToList(), i, keyLength)).Keys.ToList();
                // часто вживаний символ ------- часто вживані (одинакові, кодуються різним ключем)
                Sumbols[i] = (char)(DecodeRepeatingXOR(intel));
            }
            string keyWord = "";
            for (int i = 0; i < keyLength; i++)
            {
                keyWord += Sumbols[i];
            }
            return keyWord;
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
