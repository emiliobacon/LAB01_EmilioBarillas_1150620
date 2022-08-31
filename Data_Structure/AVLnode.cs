using System;
namespace Laboratorio01.Data_Structure
{
    public class AVLnode<T>
    {
        public T value;
        public AVLnode<T> left;
        public AVLnode<T> right;
        public AVLnode<T> father;
        public int height;

        //Constructor de mi clase AVLnode
        public AVLnode(T value)
        {
            this.value = value;
        }
    }

}