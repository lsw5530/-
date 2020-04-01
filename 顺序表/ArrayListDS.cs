using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 顺序表
{
    class ArrayListDS
    {
        private const int _defaultCapacity = 4;     //数组的初识容量
        private object[] _items;    //存放数据的数组
        private int _size;      //元素的个数

        //当长度为0的的时候  数组的状态
        private static readonly object[] emptyArray = new object[0];
        public ArrayListDS() {
            this._items = emptyArray;
        }
        public ArrayListDS(int capacity) {
            if (capacity < 0) {
                throw new ArgumentOutOfRangeException("capacity", "数组长度不能为负数");
            }
            this._items = new object[capacity];
        }
        //元素个数，只读
        public virtual int Count {
            get {
                return this._size;
            }
        }
        //容量
        public virtual int Capacity {
            get {
                return this._items.Length;
            }
            set {
                if (value != this._items.Length) {
                    if (value < this._size) {
                        throw new ArgumentOutOfRangeException("value", "容量太小了");
                    }
                    //开辟一个新的内存空间存储元素
                    object[] destinationArray = new object[value];
                    if (this._size > 0) {
                        Array.Copy(this._items, 0, destinationArray, 0, this._size);
                    }
                    this._items = destinationArray;

                }
            }
        }
        //添加元素的方法
        public virtual void Add(object value) {
            EnsureCapacity();
            this._items[this._size] = value;
            this._size++;
        }
        //索引器
        public virtual object this[int index] {
            get {
                if (index < 0 || index >= this._size) {
                    throw new ArgumentOutOfRangeException("index", "索引超出范围");
                }
                return this._items[index];
            }
            set {
                if (index < 0 || index >= this._size)
                {
                    throw new ArgumentOutOfRangeException("index", "索引超出范围");
                }
                this._items[index] = value;
            }
        }
        //裁剪空间，使存储的空间正好适合元素个数
        public virtual void TrimToSize() {
            this.Capacity = this._size;
        }
        //移除指定索引的元素
        public virtual void RemoveAt(int index) {
            if (index < 0 || index >= this._size)
            {
                throw new ArgumentOutOfRangeException("index", "索引超出范围");
            }
            this._size--;
            if (index < this._size) {
                //使删除元素后的所有元素都向前移动一位
                Array.Copy(this._items, index + 1, this._items, index, this._size - index);
            }
            //最后一个位置空出来
            this._items[this._size] = null;
        }
        public virtual void Insert(int index, object value) {
            if (index < 0 || index > this._size)
            {
                throw new ArgumentOutOfRangeException("index", "索引超出范围");
            }
            EnsureCapacity();
            if (index < this._size) {
                //插入点后面的元素全部向后移动一位
                Array.Copy(this._items,index,this._items,index+1,this._size-index);
            }
            this._items[index] = value; //插入元素
            this._size++;
        }

        //扩充容量
        private void EnsureCapacity() {
            if (this._items.Length == this._size)
            {
                int num = this._items.Length == 0 ? _defaultCapacity : this._items.Length * 2;
                this.Capacity = num;
            }
        }
    }
}
