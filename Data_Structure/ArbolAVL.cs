using Laboratorio01.Data_Structure.Cola;
using System.Collections.Generic;
using System.Diagnostics;
using System.Collections;
using System;
using System.Reflection.Metadata;
using Laboratorio01.Comparison;

namespace Laboratorio01.Data_Structure
{
    public class AVLtree<T> : IEnumerable<T>, IEnumerable  // interfaz
    {
        public Compare<T> Comparar { get; set; }
        public Compare<T> CompararNombres { get; set; }
        public Info<T> DevolverInfo { get; set; }

        public double x = 0;
        
        AVLnode<T> root;

        public AVLtree()
        {
            this.root = null;
        }

        public void Insert(T value)
        {

            AVLnode<T> newNode = new AVLnode<T>(value);

            if (this.root == null)
            {
                this.root = newNode;
                newNode.father = null;
            }
            else
            {  
                this.root = this.InsertNode(this.root, newNode);  
            }

        }

        public AVLnode<T> InsertNode(AVLnode<T> actualroot, AVLnode<T> newNode) //Metodo para insertar un nodo sino 
        {
            if (actualroot != null)//recorrer las hojas o hijos
            {
                if (Comparar(newNode.value, actualroot.value) < 0)//Cuando es menor
                {

                    actualroot.left = this.InsertNode(actualroot.left, newNode);//se manda a la nodo izquierdo
                    newNode.father = actualroot;//asigna padre

                    //Factor de balanceo
                    if (this.Node_Height(actualroot.right) - this.Node_Height(actualroot.left) == -2)
                    {
                        //Entra a rotacion simple derecha
                        if (Comparar(newNode.value, actualroot.left.value) < 0)
                        {
                            //Si L-L Rotación simple derecha
                            actualroot = this.Right_Rotation(actualroot);
                        }
                        else //rotacion left-right
                        {
                            actualroot = this.Left_Right_Rotation(actualroot);
                        }
                    }
                }
                else if (Comparar(newNode.value, actualroot.value) > 0) //cuando es mayor
                {
                    actualroot.right = this.InsertNode(actualroot.right, newNode);//se manda a la nodo derecho
                    newNode.father = actualroot;//asigna padre

                    if (this.Node_Height(actualroot.right) - this.Node_Height(actualroot.left) == 2) //validaciones de balanceo
                    {
                        //Entra a rotacion izquierda
                        if (Comparar(newNode.value, actualroot.right.value) > 0)
                        {
                            //Entra a rotacion izquerda 
                            actualroot = this.Left_Rotation(actualroot);
                        }
                        else //rotacion right - left
                        {
                            actualroot = this.Right_Left_Rotation(actualroot);
                        }
                    }
                }
                else { }
                actualroot.height = this.Max_Height(this.Node_Height(actualroot.right), this.Node_Height(actualroot.left)) + 1;
                return actualroot;
            }
            else
            {
                actualroot = newNode;
                return actualroot;
            }

        }

        //Para retornar la altura de los nodos
        public int Node_Height(AVLnode<T> node)
        {
            if (node != null)
            {
                return node.height;
            }
            else
            {
                return -1;
            }
        }
        //Para comparar dos alturas y retorna la mayor
        public int Max_Height(int height1, int height2)
        {
            if (height2 >= height1)
            {
                return height2;
            }
            else
            {
                return height1;
            }
        }

        //Rotaciones
        public AVLnode<T> Right_Rotation(AVLnode<T> node) //rotacion simple izquierda
        {
            AVLnode<T> aux_Node = node.left;
            node.left = aux_Node.right;
            aux_Node.right = node;
            node.height = this.Max_Height(this.Node_Height(node.right), this.Node_Height(node.left)) + 1;
            aux_Node.height = this.Max_Height(node.height, this.Node_Height(node.left)) + 1;
            return aux_Node;
        }
        public AVLnode<T> Left_Rotation(AVLnode<T> node) //rotacion simple derecha
        {
            AVLnode<T> aux_Node = node.right;
            node.right = aux_Node.left;
            aux_Node.left = node;
            node.height = this.Max_Height(this.Node_Height(node.left), this.Node_Height(node.right)) + 1;
            aux_Node.height = this.Max_Height(node.height, this.Node_Height(node.right)) + 1;
            return aux_Node;
        }
        public AVLnode<T> Left_Right_Rotation(AVLnode<T> node) //rotacion izquierda - derecha
        {
            node.left = this.Left_Rotation(node.left);
            AVLnode<T> aux_Node = this.Right_Rotation(node);
            return aux_Node;
        }
        public AVLnode<T> Right_Left_Rotation(AVLnode<T> node) //rotacion derecha - izquierda
        {
            node.right = this.Right_Rotation(node.right);
            AVLnode<T> aux_Node = this.Left_Rotation(node);
            return aux_Node;
        }

        public T Eliminar(T valor)
        {
            return Eliminar(valor, root);
        }

        private T Eliminar(T elemento, AVLnode<T> raiz)
        {
            AVLnode<T> aux_Node = raiz;

            if (aux_Node == null)
            {
                return default(T);
            }
            //check 
            else if (Comparar(elemento, aux_Node.value) == 0)
            {
                if (aux_Node.father.left == aux_Node)
                {
                    if (aux_Node.left == null && aux_Node.right == null)
                    {
                        aux_Node.father.left = null;
                    }
                    else
                    {
                        //si es nodo intermedio 
                    }
                }
                else if (aux_Node.father.right == aux_Node)
                {
                    if (aux_Node.left == null && aux_Node.right == null)
                    {
                        aux_Node.father.right = null;
                    }
                    else
                    {
                        //si es nodo intermedio 
                    }
                }
                aux_Node.left = null;
                aux_Node.right = null;

                return default;
            }
            else if (Comparar(elemento, aux_Node.value) < 0)
            {
                return Eliminar(elemento, aux_Node.left);
            }
            else
            {
                return Eliminar(elemento, aux_Node.right);
            }
        }

        public T Buscar(T valor)
        {
            return Buscar(valor, root);
        }

        private T Buscar(T elemento, AVLnode<T> raiz)
        {
            AVLnode<T> aux_Node = raiz;

            if (aux_Node == null)
            {
                return default(T);
            }
            else if (Comparar(elemento, aux_Node.value) == 0)
            {
                return aux_Node.value;
            }
            else if (Comparar(elemento, aux_Node.value) < 0)
            {
                return Buscar(elemento, aux_Node.left);
            }
            else
            {
                return Buscar(elemento, aux_Node.right);
            }
        }

        private void InOrder(AVLnode<T> padre, ref ColaRecorrido<T> queue)
        {

            if (padre != null)
            {
                InOrder(padre.left, ref queue);
                queue.Encolar(padre.value);
                InOrder(padre.right, ref queue);
            }
            return;
        }
 
        public IEnumerator<T> GetEnumerator()
        {
            var queue = new ColaRecorrido<T>();
            InOrder(root, ref queue);

            while (!queue.ColaVacia())
            {
                yield return queue.DesEncolar();
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

     

        public string BuscarNombres2(T valor, ref string listaNombres)
        {
            InOrder2(root, ref listaNombres, valor);

            return listaNombres;

        }


        private void InOrder2(AVLnode<T> padre, ref string listaNombres, T valor)
        {

            if (padre != null)
            {
                InOrder2(padre.left, ref listaNombres, valor);

                if (CompararNombres(valor,padre.value) == 0)
                {
                    
                    listaNombres +=  "\n" + DevolverInfo(padre.value) + "\n";
                }

                InOrder2(padre.right, ref listaNombres, valor);
            }
            return;
        }
    }
}

