using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class LinkedStack<T> : IStackDS<T>
    {
        //栈顶指针
        public StackNode<T> top;
        //元素个数
        public int count = 0;

        public int Count {
            get {
                return count;
            }
        }

        public void Clear()
        {
            count = 0;
            top = null;
        }

        public int GetLength()
        {
            return Count;
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public T Peek()
        {
            if (top == null) {
                throw new ArgumentOutOfRangeException("栈下溢，栈内没有数据");
            }
            return top.data;
        }

        public T Pop()
        {
            if (top == null)
            {
                throw new ArgumentOutOfRangeException("栈下溢，栈内没有数据");
            }
            T r = top.data;
            top = top.next;
            count--;
            return r;

        }

        public void Push(T item)
        {
            StackNode<T> newNode = new StackNode<T>(item);
            newNode.next = top;
            top = newNode;
            count++;
        }
    }
}
