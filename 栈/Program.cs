using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 栈
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            Console.WriteLine("元素个数： "+stack.Count);
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            stack.Push(40);
            Console.WriteLine("元素个数： " + stack.Count);
            int t = stack.Pop();
            Console.WriteLine("Pop : 取出数据为 = " + t + ",元素个数： " + stack.Count);

            int p = stack.Peek();
            Console.WriteLine("Peek : 取出数据为 = " + p + ",元素个数： " + stack.Count);
            stack.Clear();
            Console.WriteLine("Clear : 元素个数： " + stack.Count);

            //stack.Peek();

            Console.ReadKey();
        }
    }
}
