using System;
namespace Laboratorio01.Data_Structure
{
    public delegate int Compare<T>(T a, T b);

    public class Comparison
    {


        public static int CompareString(string a, string b)
        {
            if (a != b)
            {
                if (a.CompareTo(b) < 0)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 0;
            }
        }

        public static int CompareInt(int a, int b)
        {
            if (a != b)
            {
                if (a > b)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            else
            {

                return 0;

            }
        } 
        

  
    }
}

