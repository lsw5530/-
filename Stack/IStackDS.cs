using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    interface IStackDS<T>
    {
        int Count { get; }//元素个数
        int GetLength();
        bool IsEmpty(); //是否为空栈
        void Clear(); //清空
        void Push(T item); //入栈操作
        T Pop(); //返回栈顶数据并且出栈
        T Peek(); //取栈顶元素，不出栈

    }
}
