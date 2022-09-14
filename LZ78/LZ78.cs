using System;
using System.Collections.Generic;

namespace Laboratorio01.LZ78
{
    public class LZ78
    {
        
        public static string CodingLZ78(string a)
        {
            string text = "";
            string nextChar = "";
            int pointer = 0;
            //Diccionario 
            List<string> dic = new List<string>();


            string CompChar = "";
            int index = 0, retrn = 0;
            text = a;
            a = "<0," + text[0] + ">";
            dic.Add("");
            dic.Add(text[0] + "");

            for (int indexText = 1; indexText < text.Length; indexText++)
            {
                CompChar += text[indexText];
                if (dic.IndexOf(CompChar) != -1)
                {
                    index = dic.IndexOf(CompChar);

                    retrn = 1;

                    if (indexText + 1 == text.Length)
                    {
                        a += index + ",null>";
                    }

                }
                else
                {
                    if (retrn == 1)
                    {
                        a += "<" + index + "," + CompChar[CompChar.Length - 1] + ">";
                    }
                    else
                    {
                        a += "<0," + CompChar + ">";
                    }
                    dic.Add(CompChar);
                    CompChar = "";

                    retrn = 0;
                }

            }                 
            return a;
        }
        
    }
}

