using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JosephCircular
{
    class CircularLinkedList
    {
        private int count;  //元素个数
        private Node tail;      //尾指针
        private Node currentPrev;       //使用前驱节点标识当前节点
        //添加元素
        public void Add(object value) {
            Node newNode = new Node(value);
            if (tail == null)
            {   //是否为空链表
                tail = newNode;
                tail.next = newNode;
                currentPrev = newNode;
            }
            else {
                newNode.next = tail.next;
                tail.next = newNode;
                if (currentPrev == tail) {
                    currentPrev = newNode;
                }
                tail = newNode;
            }
            count++;
        }
        //删除当前节点
        public void RemoveCurrentNode() {
            if (tail == null)
            {
                //空链表
                throw new NullReferenceException("集合中没有任何元素");
            }
            else if (count == 1)
            {
                //只有一个元素，删除以后为空
                tail = null;
                currentPrev = null;
            }
            else {
                if (currentPrev.next == tail) {
                    //当删除的是尾巴的时候
                    tail = currentPrev;
                }
                currentPrev.next = currentPrev.next.next;
            }
            count--;
        }
        public void Move(int step) {
            //从当前节点移动指定步数
            if (step < 0) {
                throw new ArgumentOutOfRangeException("step","移动步数不能小于0");
            }
            if (tail == null) {
                //空链表
                throw new NullReferenceException("集合中没有任何元素");
            }
            for (int i = 1; i < step; i++)
            {
                currentPrev = currentPrev.next;
            }
        }
        public int Count {
            get {
                return count;
            }
        }
        public object Current {
            get {
                return currentPrev.next.data;
            }
        }
        public override string ToString()
        {
            if (tail == null) {
                return string.Empty;
            }
            string s = "";
            Node temp = tail.next;
            for (int i = 0; i < count; i++)
            {
                s += temp.ToString() + " ";
                temp = temp.next;
            }
            return s;
        }
    }
}
