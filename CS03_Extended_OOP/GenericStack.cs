using System;

namespace CS03_Extended_OOP
{
    class GenericStack<T>
    {
        private int index = 0;
        private T[] stack = new T[10];

        public void Push(T item) => stack[index++] = item;
        public T Pop() => stack[--index];
    }

    class InheritedFromGenericStack<T> : GenericStack<T>
    {
        //...
    }

    class InheritedFromGenericStackInt<T> : GenericStack<int>
    {
        //...
    }
}
