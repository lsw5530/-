using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> lst = new LinkedList<int>();
            lst.Add(0);   //添加
            lst.Add(1);
            lst.Add(2);
            lst.Add(3);
            lst.Insert(2,50);    //插入
            Console.WriteLine(lst.ToString());    // 0 1 50 2 3
            lst.RemoveAt(1);        //删除
            lst[2] = 9;     //访问
            Console.WriteLine(lst.ToString());   //0 50 9 3

            Console.ReadKey();
        }
    }
}
