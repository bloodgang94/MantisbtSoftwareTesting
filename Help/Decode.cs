using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantisbt.Help
{
    public class Decode
    {
        public static string DecodeQuotedPrintable(string str, Encoding enc)
        {
            var result = new List<byte>();

            str = str.Replace("=\r\n", "");
            for (int i = 0; i < str.Length; i++)
            {
                var c = str[i];
                switch (c)
                {
                    case '=':
                        var b = Convert.ToByte(str.Substring(i + 1, 2), 16);
                        result.Add(b);
                        i += 2;
                        break;
                    default:
                        result.Add((byte)c);
                        break;
                }
            }

            return enc.GetString(result.ToArray());
        }
    }
}
