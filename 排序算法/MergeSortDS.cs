using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 排序算法
{
    class MergeSortDS
    {
        private int[] array;        //待排序序列
        public MergeSortDS(int[] _arr) {
            this.array = _arr;
        }
        //二路归并排序
        //low high 分别是最小索引和最大索引
        private void MergeSort(int low, int high) {
            if (low < high) {
                int mid = (low + high) / 2;
                MergeSort(low, mid);        //递归左边子集合
                MergeSort(mid+1,high);      //递归右边的子集合
                Merge(low, mid, high);
            }
        }
        //将两个有序序列array[low,……,mid]和array[mid+1,……,high]
        //合并成一个有序序列array[low,……,high]
        private void Merge(int low, int mid, int high) {
            //临时空间，用于存放合并后的数据
            int[] array1 = new int[high-low+1];
            int i = low;        //左边的子集合的指针
            int j = mid + 1;      //右边的子集合的指针
            int k = 0;      //代表array1 的下标
            while(i<=mid && j<= high) {         //合并两个子集的集合
                array1[k++] = array[i] < array[j] ? array[i++] : array[j++];
            }
            while (i <= mid) {          //将左边的子集合的剩余部分复制到array1
                array1[k++] = array[i++];
            }
            while (j <= high)
            {          //将右边的子集合的剩余部分复制到array1
                array1[k++] = array[j++];
            }
            Array.Copy(array1, 0, array, low, k);       //将array1里面的有序元素全部拷贝到array里面

        }

        public void TestSort() {
            MergeSort(0,array.Length-1);
            Console.WriteLine("二路归并排序后的结果为：");
            foreach (int item in array)
            {
                Console.Write(item + " ");
            }
        }
    }
}
