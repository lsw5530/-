using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 队列
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建一个队列对象
            //Queue<int> queue = new Queue<int>();
            //创建一个循环顺序列表
            //IQueueDS<int> queue = new CSeqQueue<int>();
            //创建一个链队列
            IQueueDS<int> queue = new LinkedQueue<int>();
            queue.Enqueue(10);  //入队操作，  队头位置
            queue.Enqueue(20);
            queue.Enqueue(30);
            queue.Enqueue(40);  //队尾
            Console.WriteLine("入队数据是 10,20,30,40，队列元素个数为 ："+queue.Count);
            int dq = queue.Dequeue();    //出队，返回出队数据
            Console.WriteLine("Dequeue 出队操作，数据为："+dq+",队列元素个数为： "+queue.Count);

            int pk = queue.Peek();//只获取队头数据，不做出队操作
            Console.WriteLine("Peek 获取数据为：" + pk + ",队列元素个数为： " + queue.Count);

            queue.Clear();      //清空队列
            Console.WriteLine("Clear 清空操作,队列元素个数为： " + queue.Count);



            Console.WriteLine("=================================华丽分割线====================================");
            IQueueDS<string> cQueue = new CSeqQueue<string>();
            for (int i = 1; i < 8; i++)
            {
                cQueue.Enqueue("a"+i);  //1,2
            }
            for (int i = 0; i < 4; i++)
            {
                cQueue.Dequeue();
            }
            for (int i = 8; i < 13; i++)
            {
                cQueue.Enqueue("a" + i);  //efg
            }
            for (int i = 0; i < 4; i++)
            {
                cQueue.Dequeue();
            }
            Console.WriteLine("cQueue 获取数据为：" + cQueue.Peek() + ",队列元素个数为： " + cQueue.Count);
            Console.ReadKey();


        }
    }
}
