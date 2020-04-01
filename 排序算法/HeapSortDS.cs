using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 排序算法
{
    class HeapSortDS
    {
        private int[] array;    //待排序序列
        public HeapSortDS(int[] _array) {
            array = _array;
        }
        //数组元素的值交换
        private void Swap(int i, int j) {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        //从array[i]向下进行堆调整
        private void Heapify(int i, int size) {
            int leftIndex = i * 2 + 1;  //左孩子索引
            int rightIndex = leftIndex + 1; //右孩子索引
            int max = i;        //记录最大索引的变量
            if (leftIndex < size && array[leftIndex] > array[max]) {
                max = leftIndex;
            }
            if (rightIndex < size && array[rightIndex] > array[max]) {
                max = rightIndex;
            }
            if (i != max) {
                Swap(i,max);    //把当前结点和他的最大值结点进行交换
                Heapify(max,size);      //递归调用,继续从当前结点向下进行调整
            }
        }
        //建堆
        private void BuildHeap() {
            int n = array.Length;
            //叶子结点是从右到左从下向上开始的， 从每一个非叶子结点开始，向下进行堆调整
            for (int i = n/2-1; i >=0; i--)
            {
                Heapify(i,n);
            }
        }
        //堆排序入口
        public void HeapSort() {
            BuildHeap();        //初始化堆
            int n = array.Length;       //获取待排序序列的长度
            while (n > 1) {     //堆（无序区）元素的个数大于1，未完成排序
                n--;    
                Swap(0,n);      //将堆顶元素和最后一个元素互换，并且从堆中移除这个元素（n--）
                Heapify(0,n);       //从新的堆顶元素开始向下调整堆
            }

            Console.WriteLine("堆排序后的结果为：");
            foreach (int item in array)
            {
                Console.Write(item + " ");
            }
        }

    }
}
