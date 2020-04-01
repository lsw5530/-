using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class StackNode<T>
    {
        public T data;
        public StackNode<T> next;
        public StackNode(T value) {
            this.data = value;
        }
        public StackNode() { }

        public override string ToString()
        {
            return data.ToString();
        }
    }
}
