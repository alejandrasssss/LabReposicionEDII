using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using cifradoss.Cifrados;

namespace cifradoss.Cifrados
{
    public class Zigzag
    {
        public string Encipher(int grado, string Texto)
        {
            var Output = "";
            var LEvel = new string[grado];
            var index = 0;
            while (Texto != "")
            {
                if (index < 4) 
                {
                    for (int i = 0; i < grado; i++)
                    {
                        if (Texto == "")
                        {
                            break;
                        }
                        LEvel[i] = LEvel[i] + Texto[0].ToString();
                        Texto = Texto.Remove(0, 1);
                        index++;
                    }
                    if (Texto == "")
                    {
                        break;
                    }
                }
                else 
                {
                    for (int i = grado - 2; i > 0; i--)
                    {
                        if (Texto == "")
                        {
                            for (int r = i; r > -1; r--)
                            {
                                LEvel[r] = LEvel[r] + "$";
                            }
                            break;
                        }
                        LEvel[i] = LEvel[i] + Texto[0].ToString();
                        Texto = Texto.Remove(0, 1);
                    }
                    index = 0;
                } 

            }

            foreach (var item in LEvel)
                Output += item;
            return Output;
        }
        public string Uncipher(int Grade, string Decipher)
        {
            var Columns = (Decipher.Length + (2 * Grade) - 3) / ((2 * Grade) - 2);
            var midtline = (Columns - 1) * 2;
            var Level = new string[Grade];
            var Out = string.Empty;

            Level[0] = Decipher.Substring(0, Columns);
            Decipher = Decipher.Remove(0, Columns);
            for (int i = 1; i < Grade - 1; i++)
            {
                Level[i] = Decipher.Substring(0, midtline);
                Decipher = Decipher.Remove(0, midtline);

            }
            Level[Grade - 1] = Decipher;
            while (Level[0] != "" && Level[Grade - 1] != "")
            {
                for (int i = 0; i < Grade; i++)
                {
                    Out = Out + Level[i][0];
                    Level[i] = Level[i].Remove(0, 1);
                }
                for (int i = Grade - 2; i > 0; i--)
                {
                    Out = Out + Level[i][0];
                    Level[i] = Level[i].Remove(0, 1);
                }
            }
            Out = Out.Replace('$', ' ');
            return Out;

        }

        //public string Convert2(string s, int numRows)
        //{
        //    if (numRows <= 1) return s;
        //    var strbuilder = new StringBuilder[numRows];
        //    for (var i = 0; i < numRows; i++)
        //    {
        //        strbuilder[i] = new StringBuilder();
        //    }

        //    var step = 1;
        //    var index = 0;
        //    foreach (char ch in s)
        //    {
        //        strbuilder[index].Append(ch);
        //        if (index == 0) step = 1;
        //        if (index == numRows - 1) step = -1;

        //        index += step;
        //    }

        //    var res = new StringBuilder();
        //    for (var i = 0; i < numRows; i++)
        //    {
        //        res.Append(strbuilder[i]);
        //    }

        //    return res.ToString();
        //}

    }
}
