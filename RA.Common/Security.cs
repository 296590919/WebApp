using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Common
{
    public class Security
    {
        public static string GetMD5(string myString)
        {
            var fromData = System.Text.Encoding.Default.GetBytes(myString);
            var targetData = MD5.Create().ComputeHash(fromData);
            string byte2String = null;

            foreach (var i in targetData)
            {
                byte2String += $"{i:X2}";
            }

            return byte2String.ToUpper();
        }
    }
}
