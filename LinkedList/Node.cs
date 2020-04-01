using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Node<T>
    {
        private T data;
        private Node<T> next;
        public Node() {

        }
        public Node(T obj) {
            this.data = obj;
        }
        public override string ToString()
        {
            return data.ToString();
        }
        public T Data {
            get {
                return data;
            }
            set {
                this.data = value;
            }
        }
        public Node<T> Next {
            set {
                this.next = value;
            }
            get {
                return this.next;
            }
        }
    }
}
