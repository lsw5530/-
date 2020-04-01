using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 队列
{
    interface IQueueDS<T>
    {
        int Count { get; }//获取元素个数
        int GetLength();
        bool IsEmpty(); //是否为空队列
        void Clear(); //清空队列
        void Enqueue(T item); //入队
        T Dequeue(); //出队
        T Peek(); //取队头元素

    }
}
