using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 查找
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] arr = { 5,8,13,14,89,0,12};
            //int result = SeqSearch(arr,13);
            //Console.WriteLine("顺序查找的结果是 ： "+result);
            //int[] seqList = { 2, 8, 10, 13, 21, 36, 51, 57, 62, 69 };
            ////Console.WriteLine("查找51 ： " + Array.BinarySearch(seqList,51));      //测试C#为我们提供的二分查找接口
            ////Console.WriteLine("查找8 ： " + Array.BinarySearch(seqList, 8));
            ////Console.WriteLine("查找100 ： " + Array.BinarySearch(seqList, 100));
            //Console.WriteLine("查找51 ： " + BinarySearch(seqList, 51));      
            //Console.WriteLine("查找8 ： " + BinarySearch(seqList, 8));
            //Console.WriteLine("查找100 ： " + BinarySearch(seqList, 100));


            //SortedList 使用
            //SortedList<int, string> slist = new SortedList<int, string>();
            /*
                        //自己实现的SortedList  结构测试
                        SortedListDS<int, string> slist = new SortedListDS<int, string>();
                        Console.WriteLine("SortedList 未添加元素 ： "+slist.Count+",容量为： "+slist.Capacity);
                        slist.Add(5,"张三");
                        slist.Add(4, "李四");
                        slist.Add(6, "王五");
                        slist.Add(12, "马六");
                        slist.Add(2, "钱七");
                        slist.Add(9, "刘八");
                        Console.WriteLine("SortedList 添加元素后，个数为 ： " + slist.Count + ",容量为： " + slist.Capacity);
                        //foreach (var item in slist)
                        //{
                        //    Console.WriteLine("key = " + item.Key + ",value = " + item.Value);
                        //}
                        Console.WriteLine("所有元素：");
                        Console.WriteLine(slist.ToString());
                        slist.Remove(12);
                        Console.WriteLine("SortedList 删掉马六，个数为 ： " + slist.Count + ",容量为： " + slist.Capacity);
                        //foreach (var item in slist)
                        //{
                        //    Console.WriteLine(" 删掉马六后，key = " + item.Key + ",value = " + item.Value);
                        //}
                        Console.WriteLine("删掉马六后的，所有元素：");
                        Console.WriteLine(slist.ToString());
                        Console.WriteLine("slist[6] = "+slist[6]);

                */


            //int[] seqList = { 2, 8, 10, 13, 21, 36, 51, 57, 62, 69 };
            //Console.WriteLine("查找51 ： " + InsertionSearch(seqList, 51, 0, seqList.Length - 1));
            //Console.WriteLine("查找8 ： " + InsertionSearch(seqList, 8, 0, seqList.Length - 1));
            //Console.WriteLine("查找100 ： " + InsertionSearch(seqList, 100, 0, seqList.Length - 1));

            //1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89
            //int[] seqList = { 2, 8, 10, 13, 21, 36, 51, 57, 62, 69 };
            //Console.WriteLine("查找51 ： " + FBSearch(seqList, 51));
            //Console.WriteLine("查找8 ： " + FBSearch(seqList, 8));
            //Console.WriteLine("查找100 ： " + FBSearch(seqList, 100));

            int[] arr = {5, 8, 3, 4, 6, 1, 2, 7};
            BinarySearchTreeDS bst = new BinarySearchTreeDS(arr);
            bst.DeleteNode(6);
            bst.InOrder(bst.rootNode);
            Console.WriteLine("二叉查找树的最大值 是 = "+bst.FindMax().ToString());
            Console.WriteLine("二叉查找树的最小值 是 = " + bst.FindMin().ToString());
            Console.WriteLine("二叉查找树 查找4 的md5 是 = " + bst.Search(4).md5);
            Console.ReadKey();
        }
        //斐波那契查找
        public static int FBSearch(int[] array, int a)
        {
            if (array == null || array.Length == 0)
            {
                return -1;
            }
            else
            {
                int length = array.Length;
                int[] fb = MakeFbArray(20);// 制造一个长度为20的斐波数列
                Console.WriteLine("斐波那契数列 为　："+string.Join<int>(",",fb));
                int k = 0;
                while (length > fb[k]-1)
                {// 找出数组的长度在斐波数列（减1）中的位置，将决定如何拆分
                    k++;
                }
                Console.WriteLine("K　：" + k);
                int[] temp = new int[fb[k]-1];// 构造一个长度为fb[k] - 1的新数列
                Array.Copy(array, 0, temp, 0, length);
                for (int i = length; i < temp.Length; i++)
                {
                    if (i >= length)
                    {
                        temp[i] = array[length - 1];
                    }
                }
                int low = 0;
                int high = array.Length - 1;
                while (low <= high)
                {
                    int middle = low + fb[k - 1] - 1;
                    Console.WriteLine("k = "+k+",middle = "+middle+",low = "+low+",high = "+ high);
                    if (temp[middle] > a)
                    {
                        high = middle - 1;
                        k = k - 1;
                    }
                    else if (temp[middle] < a)
                    {
                        low = middle + 1;
                        k = k - 2;
                    }
                    else
                    {
                        if (middle <= high)
                        {
                            return middle;// 若相等则说明mid即为查找到的位置
                        }
                        else
                        {
                            return high;// middle的值已经大于hight,进入扩展数组的填充部分,即最后一个数就是要查找的数。
                        }
                    }
                }
                return -1;
                // return recurse(array, fb, a, low, hight, k);
            }
        }
        public static int[] MakeFbArray(int length)
        {
            int[] array = null;
            if (length > 2)
            {
                array = new int[length];
                array[0] = 1;
                array[1] = 1;
                for (int i = 2; i < length; i++)
                {
                    array[i] = array[i - 1] + array[i - 2];
                }
            }
            return array;
        }
        /// <summary>
        /// 顺序查找
        /// </summary>
        /// <param name="sourceArr">查找表</param>
        /// <param name="K">目标值</param>
        /// <returns>在查找表中的索引，失败返回-1</returns>
        static int SeqSearch(int[] sourceArr, int K) {
            for (int i = 0; i < sourceArr.Length; i++)
            {
                if (sourceArr[i] == K) {
                    //查找成功
                    return i;
                }
            }
            //查找失败
            return -1;
        }
        /// <summary>
        /// 二分查找
        /// </summary>
        /// <param name="seqList">查找表</param>
        /// <param name="k">目标值</param>
        /// <returns>在查找表中的索引，失败返回补码</returns>
        static int BinarySearch(int[] seqList, int k) {
            int mid;
            int low = 0;
            int high = seqList.Length - 1;
            while (low <= high) {
                mid = (low + high) / 2;     //中间索引  mid = low+((high-low)>>1);
                if (k == seqList[mid])
                {
                    return mid;     //查找成功
                }
                else if (k > seqList[mid])
                {
                    low = mid + 1;      //在右部分继续查找
                }
                else {
                    high = mid - 1;     //在左半部分继续查找
                }
            }
            return ~low;        //查找失败，返回插入点的补码
        }
        /// <summary>
        /// 插入查找
        /// </summary>
        /// <param name="arr">查找表</param>
        /// <param name="k">目标值</param>
        /// <param name="low">最小索引</param>
        /// <param name="high">最大索引</param>
        /// <returns></returns>
        static int InsertionSearch(int[] arr, int k, int low, int high) {
            //　mid=low+(key-a[low])/(a[high]-a[low])*(high-low)，

            if (low <= high)
            {
                int mid = low + (k - arr[low]) / (arr[high] - arr[low]) * (high - low);
                if (arr[mid] == k)
                {
                    return mid;
                }
                else if (arr[mid] > k)
                {
                    return InsertionSearch(arr, k, low, mid - 1);
                }
                else
                {
                    return InsertionSearch(arr, k, mid + 1, high);
                }
            }
            else {
                return ~low;
            }
            
        }
    }
}
