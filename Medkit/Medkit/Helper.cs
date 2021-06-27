// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Medkit
{
    public class Helper
    {
        private static readonly byte[] _salt = Encoding.Unicode.GetBytes("ssqjkSgn2385");
        public static string GetDeclesion(int number, string nominativ, string genetiv, string plural)
        {
            number %= 100;
            if (number >= 11 && number <= 19)
            {
                return plural;
            }

            var i = number % 10;
            switch (i)
            {
                case 1:
                    return nominativ;
                case 2:
                case 3:
                case 4:
                    return genetiv;
                default:
                    return plural;
            }
        }
        public static string GeneratedHashString(string strnohash)
        {
            string hash = string.Empty;
            strnohash += _salt;
            byte[] byteString = Encoding.Unicode.GetBytes(strnohash);
            using (SHA256Managed sHA256 = new SHA256Managed())
            {
                byte[] hashBytes = sHA256.ComputeHash(byteString);

                foreach (byte x in hashBytes)
                {
                    hash += string.Format("{0:x2}", x);
                }
            }
            return hash;
        }
    }
}
