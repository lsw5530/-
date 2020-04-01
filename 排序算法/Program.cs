using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 排序算法
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] R1 = {0, 3, 6, 5, 9, 7, 1, 8, 2, 4 };        //待排序的数组
            int[] R = { 3, 6, 5, 9, 7, 1, 8, 2, 4 };        //待排序的数组
            //InsertionSort(R);
            //InsertionSort1(R1);
            //BinarySort(R);
            //ShellSort(R);
            //BubbleSort(R);
            //CockTailSort(R);
            //QuickSort(R,0,R.Length-1);
            //Console.WriteLine("快速排序后的结果为：");
            //foreach (var item in R)
            //{
            //    Console.Write(item + " ");
            //}
            //SelectionSort(R);
            //HeapSortDS hpd = new HeapSortDS(R);
            //hpd.HeapSort();
            MergeSortDS msd = new MergeSortDS(R);
            msd.TestSort();
            Console.ReadKey();
        }
        //直接插入排序
        static void InsertionSort(int[] arr) {
            for (int i = 1; i < arr.Length; i++)
            {
                int temp = arr[i];      //待插入的元素
                int j = i - 1;      //开始检索的位置
                while (j >=0 && temp < arr[j]) {
                    arr[j + 1] = arr[j];        //移动元素
                    j--;
                }
                arr[j + 1] = temp;
            }
            Console.WriteLine("直接插入排序后的结果为：");
            foreach (int item in arr)
            {
                Console.Write(item+" ");
            }
        }
        //直接插入排序 监视哨
        static void InsertionSort1(int[] arr)
        {
            for (int i = 2; i < arr.Length; i++)
            {
                arr[0] = arr[i];      //待插入的元素
                int j = i - 1;      //开始检索的位置
                while (arr[0] < arr[j])
                {
                    arr[j + 1] = arr[j];        //移动元素
                    j--;
                }
                arr[j + 1] = arr[0];
            }
            Console.WriteLine("直接插入排序优化后的结果为：");
            for (int i = 1; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }
        //二分插入排序
        static void BinarySort(int[] arr) {
            for (int i = 1; i < arr.Length; i++)
            {
                int temp = arr[i];      //待插入的元素
                int low = 0;    //低位
                int high = i - 1;
                while (low <= high) {
                    int mid = (low+high)/ 2;//中间的数据索引
                    if (temp > arr[mid])
                    {
                        low = mid + 1;
                    }
                    else {
                        high = mid - 1;
                    }
                }
                for (int j = i-1; j >=low; j--)
                {
                    arr[j + 1] = arr[j];
                }
                arr[low] = temp;
            }
            Console.WriteLine("二分插入排序后的结果为：");
            foreach (int item in arr)
            {
                Console.Write(item + " ");
            }
        }
        //希尔排序
        static void ShellSort(int[] arr) {
            //步长的循环，每次步长/2
            for (int gap = arr.Length/2; gap >=1; gap = gap/2)
            {
                //起始步长往后一次跟前面的对应比较
                for (int i = gap; i < arr.Length; i++)
                {
                    int temp = arr[i];
                    int j = i - gap;
                    //移动元素，找到元素要插入的位置
                    while (j >= 0 && temp < arr[j]) {
                        arr[j + gap] = arr[j];      //移动元素
                        j = j - gap;
                    }
                    arr[j + gap] = temp;
                }
            }
            Console.WriteLine("希尔排序后的结果为：");
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
        }
        //冒泡排序
        static void BubbleSort(int[] arr) {
            //外层循环每次把参与排序的最大数排在最后
            for (int i = 1; i < arr.Length; i++)
            {
                bool isSwap = false;    //是否交换了
                //内层循环负责对比相邻的两个数，并且把大的排在后面
                for (int j = 0; j < arr.Length-i; j++)
                {
                    //如果前一个数比后一个数大，交换位置
                    if (arr[j] > arr[j + 1]) {
                        isSwap = true;
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j+1] = temp;
                    }
                }
                if (!isSwap) {
                    break;
                }
            }
            Console.WriteLine("冒泡排序后的结果为：");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]+" ");
            }
        }
        //鸡尾酒排序
        static void CockTailSort(int[] arr)
        {
            //外层循环每次把参与排序的最大数排在最后
            for (int i = 1; i < arr.Length/2; i++)
            {
                bool isSwap = false;    //是否交换了
                //内层循环负责对比相邻的两个数，并且把大的排在后面
                for (int j = 0; j < arr.Length - i; j++)
                {
                    //如果前一个数比后一个数大，交换位置
                    if (arr[j] > arr[j + 1])
                    {
                        isSwap = true;
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
                for (int j = arr.Length-i; j >=i; j--)
                {
                    //如果前一个数比后一个数大，交换位置
                    if (arr[j-1] > arr[j])
                    {
                        isSwap = true;
                        int temp = arr[j];
                        arr[j] = arr[j - 1];
                        arr[j - 1] = temp;
                    }
                }
                if (!isSwap)
                {
                    break;
                }
            }
            Console.WriteLine("鸡尾酒排序后的结果为：");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }
        //
        /// <summary>
        /// 快速排序
        /// </summary>
        /// <param name="arr">待排序的序列</param>
        /// <param name="low">最小索引</param>
        /// <param name="high">最大索引</param>
        static void QuickSort(int[] arr, int low, int high) {
            if (low < high) {   //确保区间里面至少有一个元素
                int i = low;    //左边的那个索引号
                int j = high;   //右边的索引号
                int temp = arr[i];        //基准值
                while (i < j) {         //从区间的两端交替向中间扫描，直到碰头，j=i
                    while (i<j && arr[j] >= temp) {
                        j--;    //从右到左扫描，直到找到比基准值小的元素
                    }
                    arr[i] = arr[j];
                    while (i < j && arr[i] <= temp) {
                        i++;        //从左到右扫描，直到找到比基准值大的元素
                    }
                    arr[j] = arr[i];
                }
                arr[i] = temp;      //基准值 回归正确的位置
                QuickSort(arr, low, i - 1);     //递归左边的区间
                QuickSort(arr, i+1, high);     //递归右边的区间
            }
        }

        //直接选择排序
        static void SelectionSort(int[] arr)
        {
            //需要比较的次数，i 要选择的目标位置
            for (int i = 0; i < arr.Length-1; i++)
            {
                int k = i;      //k 用于记录一趟排序中最小的那个索引号
                for (int j = i+1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[k]) {  //发现比arr[k] 小的元素
                        k = j;  //把数值较小的那个索引号 赋值给k
                    }
                }
                if (k != i) { //交换 arr[i]  arr[k]的值，把最小的放在最左边
                    int temp = arr[i];
                    arr[i] = arr[k];
                    arr[k] = temp;
                }
            }
            Console.WriteLine("选择排序后的结果为：");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }
    }
}
