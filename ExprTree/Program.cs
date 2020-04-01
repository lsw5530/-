using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExprTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入一个四则表达式");
            string expStr = Console.ReadLine();
            //创建二叉树
            BinaryTree bTree = new BinaryTree(expStr);
            Console.WriteLine("结果为： "+bTree.GetResult());

            Console.ReadKey();
        }
    }
}
