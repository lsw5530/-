using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class SeqStack<T> : IStackDS<T>
    {
        private T[] _array;     //存放元素的数组
        private int top = -1;
        private const int _defaultCapacity = 10;        //默认容量
        public SeqStack():this(_defaultCapacity) {
        }
        public SeqStack(int capacity) {
            if (capacity < 0) {
                throw new ArgumentOutOfRangeException("栈容量不能小于0");
            }
            if (capacity < _defaultCapacity) {
                capacity = _defaultCapacity;
            }
            this._array = new T[capacity];
        }
        public virtual int Count {
            get {
                return top + 1;
            }
        }

        public virtual void Clear()
        {
            top = -1;
        }

        public virtual int GetLength()
        {
            return Count;
        }

        public virtual bool IsEmpty()
        {
            return top == -1;
        }

        public virtual T Peek()
        {
            if (IsEmpty()) {
                throw new InvalidOperationException("栈下溢，栈内没有数据了");
            }
            return this._array[top];

        }
        public virtual T Pop()
        {
            T t = Peek();
            top--;
            return t;
        }

        public virtual void Push(T item)
        {
            if (Count == this._array.Length) {
                //把空间变为原来的2倍
                T[] destinationArray = new T[this._array.Length *2];
                //把原来数组的数据copy到目标数组
                Array.Copy(this._array,0,destinationArray,0,this.Count);
                this._array = destinationArray;
            }
            this._array[++top] = item;
        }
    }
}
