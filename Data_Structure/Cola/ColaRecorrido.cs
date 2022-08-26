using System;
namespace Laboratorio01.Data_Structure.Cola
{
    public class ColaRecorrido<T>
    {
        NodoSimple<T> _cabeza = new NodoSimple<T>();
        NodoSimple<T> Cola = new NodoSimple<T>();
        NodoSimple<T> Retorno = new NodoSimple<T>();

        public void Encolar(T data)

        {
            NodoSimple<T> Nuevo = new NodoSimple<T>();
            Nuevo.Valor = data;

            if (_cabeza.Valor == null)
            {
                _cabeza = Nuevo;
                Cola = Nuevo;
            }
            else
            {
                Cola.Siguiente = Nuevo;
                Cola = Nuevo;
            }
        }

        public T DesEncolar()
        {
            if (_cabeza != null)
            {
                Retorno = _cabeza;
                _cabeza = _cabeza.Siguiente;
                if (_cabeza == null)
                {
                    Cola = null;
                }
            }
            return Retorno.Valor;
        }

        public bool ColaVacia()
        {
            return _cabeza == null;
        }
    }
}

