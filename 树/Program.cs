using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 树
{
    class Program
    {
        static void Main(string[] args)
        {
            string cStr = "ABCDE#F";
            BinaryTree bTree = new BinaryTree(cStr);//使用字符串构造二叉树
            Console.Write("先序遍历：");
            bTree.PreOrder(bTree.Head); //先序遍历
            Console.WriteLine();
            Console.Write("中序遍历：");
            bTree.MidOrder(bTree.Head); //中序遍历
            Console.WriteLine();
            Console.Write("后序遍历：");
            bTree.AfterOrder(bTree.Head); //后序遍历
            Console.WriteLine();

            Console.Write("广度优先遍历：");
            bTree.LevelOrder();
            Console.ReadKey();
        }
    }
}
