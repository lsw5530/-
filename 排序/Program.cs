using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 排序
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] R = { 3, 6, 5, 9, 7, 1, 8, 2, 4 };        //待排序数组
            InsertionSort(R);
            Console.ReadKey();
        }
        //插入排序
        static void InsertionSort(int[] arr) {
            for (int i = 1; i < arr.Length; i++)
            {
                int temp = arr[i];      //待插入的元素
                int j = i - 1;      //要比较的开始位置，从后往前找
                while (j >= 0 && temp < arr[j]) {
                    arr[j + 1] = arr[j];        //移动元素
                    j--;
                }
                arr[j + 1] = temp;//将元素插入到了适合的位置
            }
            Console.WriteLine("直接插入排序后的序列为：");
            foreach (int item in arr)
            {
                Console.Write(item+" ");
            }
        }
    }
}
