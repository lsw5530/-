using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 队列
{
    /// <summary>
    /// 链队列的 节点类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class QueueNode<T>
    {
        public T data;
        public QueueNode<T> next;
        public QueueNode(T _data) {
            this.data = _data;
        }
        public override string ToString()
        {
            return data.ToString();
        }
    }
}
