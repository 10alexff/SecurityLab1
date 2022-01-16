using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Utilites
    {
        public static string Convert_by16(string msg)
        {
            var bytes = new byte[msg.Length / 2];

            for (var i = 0; i < msg.Length / 2; i++)
            {
                string couple = "";
                couple += msg[i * 2];
                couple += msg[i * 2 + 1];
                bytes[i] = Convert.ToByte(couple, 16);
            }

            return Encoding.UTF8.GetString(bytes);
        }

        public static double PartOfText(string input)
        {
            int count = 0;

            foreach (var ch in input.ToCharArray())
            {
                if (Char.IsLetter(ch) || Char.IsPunctuation(ch) || Char.IsWhiteSpace(ch))
                    count++;
            }

            var result = count / input.Length;
            return result;

        }

        public static double Hamming(List<byte> x, List<byte> y)
        {
            byte[] nbits =
           {
            0, 1, 1, 2, 1, 2, 2, 3, 1, 2, 2, 3, 2, 3, 3, 4,
            1, 2, 2, 3, 2, 3, 3, 4, 2, 3, 3, 4, 3, 4, 4, 5,
            1, 2, 2, 3, 2, 3, 3, 4, 2, 3, 3, 4, 3, 4, 4, 5,
            2, 3, 3, 4, 3, 4, 4, 5, 3, 4, 4, 5, 4, 5, 5, 6,
            1, 2, 2, 3, 2, 3, 3, 4, 2, 3, 3, 4, 3, 4, 4, 5,
            2, 3, 3, 4, 3, 4, 4, 5, 3, 4, 4, 5, 4, 5, 5, 6,
            2, 3, 3, 4, 3, 4, 4, 5, 3, 4, 4, 5, 4, 5, 5, 6,
            3, 4, 4, 5, 4, 5, 5, 6, 4, 5, 5, 6, 5, 6, 6, 7,
            1, 2, 2, 3, 2, 3, 3, 4, 2, 3, 3, 4, 3, 4, 4, 5,
            2, 3, 3, 4, 3, 4, 4, 5, 3, 4, 4, 5, 4, 5, 5, 6,
            2, 3, 3, 4, 3, 4, 4, 5, 3, 4, 4, 5, 4, 5, 5, 6,
            3, 4, 4, 5, 4, 5, 5, 6, 4, 5, 5, 6, 5, 6, 6, 7,
            2, 3, 3, 4, 3, 4, 4, 5, 3, 4, 4, 5, 4, 5, 5, 6,
            3, 4, 4, 5, 4, 5, 5, 6, 4, 5, 5, 6, 5, 6, 6, 7,
            3, 4, 4, 5, 4, 5, 5, 6, 4, 5, 5, 6, 5, 6, 6, 7,
            4, 5, 5, 6, 5, 6, 6, 7, 5, 6, 6, 7, 6, 7, 7, 8,
            };


            int d = 0;

            for (int i = 0; i < x.Count; i++)
            {
                byte xorByte = (byte)(x[i] ^ y[i]);
                d += nbits[xorByte];
            }
            return d;
        }

        public static List<byte> division(List<byte> ArrayOFbyte, int index_letter, int keyLength)
        {
            var result = new List<byte>();
            for (int i = index_letter; i < ArrayOFbyte.Count; i += keyLength)
            {
                result.Add(ArrayOFbyte[i]);
            }
            return result;
            // повертає список байтів - символів повідомлення, закодованих одним символом ключа
        }
    }
}
