using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 队列
{
    class LinkedQueue<T> : IQueueDS<T>
    {
        public QueueNode<T> front;      //队头
        public QueueNode<T> rear;       //队尾
        public int count;       //元素的个数
        public LinkedQueue() {
            Clear();
        }
        public int Count {
            get {
                return count;
            }
        }

        public void Clear()
        {
            front = null;
            rear = null;
            count = 0;
        }
        //出队操作
        public T Dequeue()
        {
            if (this.front == null)
            {
                throw new ArgumentOutOfRangeException("队列下溢，队列里面没有数据");
            }
            T t = this.front.data;
            if (count == 1)
            {
                this.front = null;
                this.rear = null;
            }
            else {
                this.front = this.front.next;
            }
            count--;
            return t;
        }
        //入队操作
        public void Enqueue(T item)
        {
            QueueNode<T> newNode = new QueueNode<T>(item);
            if (this.rear == null)
            {
                this.front = newNode;
                this.rear = newNode;
            }
            else {
                this.rear.next = newNode;
                this.rear = newNode;
            }
            count++;
        }

        public int GetLength()
        {
            return count;
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public T Peek()
        {
            if (this.front == null) {
                throw new ArgumentOutOfRangeException("队列下溢，队列里面没有数据");
            }
            return this.front.data;
        }
    }
}
