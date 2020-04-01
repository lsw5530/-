using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            //创建栈对象
            //Stack<int> stack = new Stack<int>();
            //测试顺序栈
            //IStackDS<int> stack = new SeqStack<int>();
            //测试链栈
            IStackDS<int> stack = new LinkedStack<int>();
            Console.WriteLine("元素个数为 ： "+stack.Count);
            stack.Push(10);  //栈底
            stack.Push(20);
            stack.Push(30);
            stack.Push(40);
            Console.WriteLine("Push 10,20,30,40 ,元素个数为 ： " + stack.Count);
            int p = stack.Pop();  //取出数据，并且出栈
            Console.WriteLine("Pop ,元素个数为 ： " + stack.Count+",取出的数据为： "+p);
            int peek = stack.Peek();    //取出数据，不删除
            Console.WriteLine("Peek ,元素个数为 ： " + stack.Count + ",取出的数据为： " + peek);

            stack.Clear();
            Console.WriteLine("Clear ,元素个数为 ： " + stack.Count);

            //stack.Peek();
            */


            Console.WriteLine(DecConvert(27635,16));

            Console.WriteLine(DecConvert(350, 8));

            Console.ReadKey();



        }
        //参数N表示要转换的十进制数，参数D表示转换为D 进制
        static string DecConvert(int N,int D) {
            if (D < 2 || D > 16) {
                throw new ArgumentOutOfRangeException("D","只支持二进制到十六进制的转换");
            }
            Stack<char> stack = new Stack<char>();
            do
            {
                int residue = N % D;        //取余
                char c = residue < 10 ? (char)(residue + 48) : (char)(residue + 55);
                
                stack.Push(c);  //进栈
                N = N / D;
            } while (N != 0);       //当除的结果为0时表示已经到最后一位了
            string s = string.Empty;
            while (stack.Count > 0) {
                //所有的元素出栈并压入字符串s内
                s += stack.Pop().ToString();
            }
            return s;
        }
    }
}
