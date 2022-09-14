using System;
using Laboratorio01.Models;
using Laboratorio01.LZ78;

namespace Laboratorio01.Comparison
{
    public delegate int Compare<T>(T a, T b);

    //carlos laparra 1031120 me ayudó en esta parte 

    public delegate string Info<T>(T a);

    public delegate void Encolar<T>(T a);

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

        public static string returnInfo( ClientModel a)
        {
            string info = "Id: " + a.Id + ", Nombre: " + a.FullName + ", Fecha de Nacimiento: " + a.Birthdate + ", Dirección: " + a.Address;


            return info;
        }

        public static void encolarCompanies(ClientModel a)
        {
            string phrase = a.Companies;
            a.Companies = "";

            string[] words = phrase.Split(' ');
            foreach (var word in words)
            {
                string aCodificar = word; //+ a.Id;

                a.Companies += word + ": " + LZ78.LZ78.CodingLZ78(aCodificar) + " ";

            }
        }
    }
}

