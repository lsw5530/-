using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class LinkedList<T>
    {
        private Node<T> head;
        private int count;
        public LinkedList()
        {
        }
        public LinkedList(T _head) {
            this.head = new Node<T>(_head);
        }
        //添加元素
        public virtual void Add(T value) {
            Node<T> newNode = new Node<T>(value);
            if (this.head == null)
            {
                this.head = newNode;
            }
            else {
                Node<T> lastNode = GetByIndex(count-1);
                lastNode.Next = newNode;
            }
            count++;
        }
        //元素个数
        public int Count {
            get {
                return count;
            }
        }
        //索引器
        public T this[int index] {
            get {
                return GetByIndex(index).Data;
            }
            set {
                GetByIndex(index).Data = value;
            }
        }
        //查找指定索引的元素
        private Node<T> GetByIndex(int index) {
            if (index < 0 || index >= this.count) {
                throw new ArgumentOutOfRangeException("index","索引超出范围");
            }
            Node<T> tempNode = this.head;
            for (int i = 0; i < index; i++)
            {
                tempNode = tempNode.Next;
            }
            return tempNode;
        }

        public virtual void Insert(int index, T value) {
            Node<T> newNode = new Node<T>(value);       //新节点
            //如果在开始位置插入
            if (index == 0)
            {
                if (this.head == null)
                {
                    this.head = newNode;
                }
                else
                {
                    newNode.Next = head;
                    this.head = newNode;
                }
            }
            else {
                Node<T> prevNode = GetByIndex(index - 1);       //查找插入点的前驱节点
                Node<T> nextNode = prevNode.Next;               //插入点的后继节点
                prevNode.Next = newNode;        //前驱节点的后继节点为新节点
                newNode.Next = nextNode;        //新节点的后继几点指向原来的前驱的后继
            }
            count++;
        }
        //根据索引删除元素
        public virtual void RemoveAt(int index) {
            //删除头结点
            if (index == 0)
            {
                if (this.head == null)
                {
                    throw new ArgumentOutOfRangeException("index", "索引超出范围");
                }
                this.head = head.Next;
            }
            else {
                //查找删除节点的前驱节点
                Node<T> prevNode = GetByIndex(index-1);
                if (prevNode.Next == null) {
                    throw new ArgumentOutOfRangeException("index","索引超出范围");
                }
                prevNode.Next = prevNode.Next.Next;
            }
            count--;
        }

        public override string ToString()
        {
            string s = "";
            Node<T> temp = head;
            while(temp != null) { 
                s += temp.ToString() + " ";
                temp = temp.Next;
            }
            return s;
        }
    }
}
