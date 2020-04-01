using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 队列
{
    class CSeqQueue<T> : IQueueDS<T>
    {
        //存放元素的数组
        public T[] _array;
        //增长因子 1-10之间
        private int _growfactor;
        //最小增长值
        private const int _MinimumGrow = 4;
        //默认队列空间的大小
        private const int _defaultCapacity = 8;
        //元素的个数
        private int _size = 0;
        //队头指针  指向队头的第一个元素
        private int _head;
        //队尾指针  指向队尾的最后一个元素索引+1
        private int _tail;
        public CSeqQueue() : this(_defaultCapacity,2){ }

        public CSeqQueue(int capacity, float growFactor) {
            if (capacity < 0) {
                throw new ArgumentOutOfRangeException("capacity","初识容量不能小于0");
            }
            if (capacity < _defaultCapacity) {
                capacity = _defaultCapacity;
            }
            if (growFactor < 1.0 || growFactor > 10.0) {
                throw new ArgumentOutOfRangeException("growFactor","增长因子必须在1-10之间");
            }
            this._array = new T[capacity];  //初始化数组
            this._head = this._tail = 0;
            this._size = 0;
            this._growfactor = (int)(growFactor * 100f);
        }
        //获取元素个数
        public int Count {
            get {
                return this._size;
            }
        }

        public void Clear()
        {
            this._head = this._tail = this._size = 0;
        }
        //出队操作
        public T Dequeue()
        {
            if (this._size == 0)
            {
                throw new InvalidOperationException("队列下溢，队里里没有数据");
            }
            T obj = this._array[_head]; //出队数据
            this._array[_head] = default(T);        //在数组里删除出队元素
            this._head = (this._head + 1) % this._array.Length;   //循环队列  处理机制，保证下标是循环的
            this._size--;
            return obj;
        }
        //入队
        public void Enqueue(T item)
        {
            if (this._size == this._array.Length) {
                //计算新的容量
                int capacity = (int)(this._array.Length * this._growfactor / 100f);
                if (capacity < this._array.Length + _MinimumGrow) {
                    //最少要增长四个元素
                    capacity = this._array.Length + _MinimumGrow;
                }
                //调整容量
                SetCapacity(capacity);
            }
            this._array[_tail] = item;  //入队
            this._tail = (this._tail + 1) % this._array.Length;     //移动尾巴指针
            this._size++;
        }
        private void SetCapacity(int capacity) {    //内存搬家
            T[] destinationArray = new T[capacity];
            if (this._head < this._tail)
            {
                //头指针在尾指针的前面
                Array.Copy(this._array, this._head, destinationArray, 0, this._size);
            }
            else {
                //头指针在尾指针的后面
                Array.Copy(this._array, this._head, destinationArray, 0, this._array.Length-this._head);
                Array.Copy(this._array, 0, destinationArray, this._array.Length - this._head, this._tail);
            }
            this._array = destinationArray;
            this._head = 0;
            this._tail = (this._size == capacity) ? 0 : this._size;
        }
        public int GetLength()
        {
            return this._size;
        }

        public bool IsEmpty()
        {
            return this._size == 0;
        }
        //获取队头元素，不删除
        public T Peek()
        {
            if (this._size == 0) {
                throw new InvalidOperationException("队列下溢，队里里没有数据");
            }
            T obj = this._array[_head]; //出队数据
            //this._array[_head] = default(T);        //在数组里删除出队元素
            //this._head = (this._head + 1) % this._array.Length;
            return obj;
        }
    }
}
