using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JosephCircular
{
    class Program
    {
        static void Main(string[] args)
        {
            CircularLinkedList cList = new CircularLinkedList();
            string result = string.Empty;       //记录出队的顺序
            Console.WriteLine("请输入总人数：");
            int count = int.Parse(Console.ReadLine());
            Console.WriteLine("请输入出队的数字：");
            int outNum = int.Parse(Console.ReadLine());
            Console.WriteLine("游戏开始");
            for (int i = 1; i <= count; i++)
            {
                //添加元素
                cList.Add(i);
            }
            Console.WriteLine("所有人 ： " + cList.ToString());
            while (cList.Count>16) {
                cList.Move(outNum);
                result += cList.Current.ToString() + " ";
                cList.RemoveCurrentNode();      //删掉当前节点 出队
                Console.WriteLine("剩余的人数： "+cList.ToString()+",开始报数的人数 = "+cList.Current.ToString());
            }
            Console.WriteLine("出队的顺序： "+result+cList.Current.ToString());
            Console.ReadKey();
        }
    }
}
