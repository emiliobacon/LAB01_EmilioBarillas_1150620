using System;
using Laboratorio01.Models;

namespace Laboratorio01.Comparison
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

        public static int CompararNombres(ClientModel a, ClientModel b)
        {
            if (a.FullName == b.FullName)
            {
                return 0;
            }
            else return 1;
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

        public static int CompararID(ClientModel a, ClientModel b)
        {

            if (a.Id != b.Id)
            {
                if (a.Id < b.Id)
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

        public static int CompararFullName(ClientModel a, ClientModel b)
        {

            if (a.FullName != b.FullName)
            {
                if (a.FullName.CompareTo(b.FullName) < 0)
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

        public static ClientModel CompararFullName(string a)
        {
            ClientModel parametro = new ClientModel();
            parametro.FullName = a;
            return parametro;
        }

    }
}

