using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 顺序表
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList arrList = new ArrayList();
            Console.WriteLine("Count = "+arrList.Count+",Capacity = "+arrList.Capacity);

            arrList.Add(5);
            Console.WriteLine("Count = " + arrList.Count + ",Capacity = " + arrList.Capacity);
            arrList.Add("hello");
            arrList.Add(18);
            arrList.Add("你好");
            arrList.Add("180");

            
            //Console.WriteLine("Count = " + arrList.Count + ",Capacity = " + arrList.Capacity);
            //arrList.TrimToSize();
            //Console.WriteLine("Count = " + arrList.Count + ",Capacity = " + arrList.Capacity);
            //Console.WriteLine("arrList[1] = "+arrList[1]);

            //arrList.RemoveAt(1);
            //Console.WriteLine("arrList[1] = " + arrList[1]);
            //Console.WriteLine("Count = " + arrList.Count + ",Capacity = " + arrList.Capacity);

            //arrList.TrimToSize();
            //Console.WriteLine("Count = " + arrList.Count + ",Capacity = " + arrList.Capacity);

            arrList.Insert(1,"world");
            Console.WriteLine("Count = " + arrList.Count + ",Capacity = " + arrList.Capacity);
            for (int i = 0; i < arrList.Count; i++)
            {
                Console.WriteLine(i+" = "+arrList[i]);
            }
            Console.WriteLine("==================================MY ARRAY LIST =================================");

            ArrayListDS arrListDS = new ArrayListDS();
            Console.WriteLine("Count = " + arrListDS.Count + ",Capacity = " + arrListDS.Capacity);
            arrListDS.Add(5);
            Console.WriteLine("Count = " + arrListDS.Count + ",Capacity = " + arrListDS.Capacity);
            arrListDS.Add("hello");
            arrListDS.Add(18);
            arrListDS.Add("你好");
            arrListDS.Add("18");
            //Console.WriteLine("Count = " + arrListDS.Count + ",Capacity = " + arrListDS.Capacity);
            //arrListDS.TrimToSize();
            //Console.WriteLine("Count = " + arrListDS.Count + ",Capacity = " + arrListDS.Capacity);
            //Console.WriteLine("arrListDS[1] = " + arrListDS[1]);
            //arrListDS[1] = "五斗米";
            //Console.WriteLine("arrListDS[1] = " + arrListDS[1]);

            //arrListDS.RemoveAt(1);
            //Console.WriteLine("arrListDS[1] = " + arrListDS[1]);

            arrListDS.Insert(1, "world");
            for (int i = 0; i < arrListDS.Count; i++)
            {
                Console.WriteLine(i + " = " + arrListDS[i]);
            }

            Console.ReadKey();
        }
    }
}
