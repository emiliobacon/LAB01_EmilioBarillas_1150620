using System;
using System.Collections.Generic;

namespace Laboratorio01.LZ78
{
    public class LZ78
    {     
        public static List<string> dic = new List<string>();
        public static string text = "";
        public static string nextChar = "";
        public static int pointer = 0;

        public static string CodingLZ78(string a)
        {
            string CompChar = "";
            int index = 0, retrn = 0;
            text = a;
            a = "0 " + text[0] + "\n";
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
                        a += index + " null\n";
                    }

                }
                else
                {
                    if (retrn == 1)
                    {
                        a += index + " " + CompChar[CompChar.Length - 1] + "\n";
                    }
                    else
                    {
                        a += "0 " + CompChar + "\n";
                    }
                    dic.Add(CompChar);
                    CompChar = "";

                    retrn = 0;
                }

            }                 
            return a;
        }

        public static string decodingLZ78(string a)
        {
            

            string text = a;
            string[] CompRslt = a.Split();
            a = "";

            for (int i = 0; i < text.Length; i += 2)
            {
                if (CompRslt[i].Length == 0)
                {
                    break;
                }

                pointer = int.Parse(CompRslt[i]);

                nextChar = CompRslt[i + 1];
                if (nextChar != "null")
                {
                    a += dic[pointer] + nextChar;
                }
                else
                {
                    a += dic[pointer];
                }
                pointer = 0;
                nextChar = "";
                
            }
            pointer = 0;
            nextChar = "";
            dic.Clear();

            return a;
        }
        
    }
}

