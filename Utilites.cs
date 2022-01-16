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
    }
}
