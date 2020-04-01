using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 查找
{
    class SortedListDS<T,K>
    {
        private T[] keys;       //存放键的数组
        private K[] values;     //存放值的数组
        private int _size;      //集合中元素的个数
        private const int _defaultCapacity = 8;     //默认的容量

        public SortedListDS():this(0) {     //初始化时没有任何元素
        }
        public SortedListDS(int _capacity) {        //指定容量的构造方法
            if (_capacity < 0) {
                throw new ArgumentOutOfRangeException("容量的值不能小于0");
            }
            keys = new T[_capacity];
            values = new K[_capacity];
            _size = 0;
        }
        //元素个数属性
        public virtual int Count {
            get {
                return _size;
            }
        }
        //实现容量属性
        public virtual int Capacity {
            get {
                return keys.Length;
            }
            set {
                if(value != keys.Length) {
                    if (value < _size) {
                        throw new ArgumentOutOfRangeException("容量太小了");
                    }
                    //开辟新空间
                    T[] newKeys = new T[value];
                    K[] newValues = new K[value];
                    if (_size > 0) {
                        //元素搬家
                        Array.Copy(keys,0,newKeys,0,_size);
                        Array.Copy(values, 0, newValues, 0, _size);
                    }
                    keys = newKeys;
                    values = newValues;
                }
            }
        }

        //添加元素的方法
        public virtual void Add(T key, K val) {
            int i = Array.BinarySearch(keys,0,_size,key);
            if (i >= 0) {
                throw new ArgumentException("插入了重复键");
            }
            Insert(~i,key,val);     //插入操作
        }
        private void Insert(int index, T key, K val) {
            if (_size == keys.Length) {
                //如果满员就扩容，个数
                this.Capacity = keys.Length == 0 ? _defaultCapacity : keys.Length * 2;
            }
            if (index < _size) {
                //插入位置的后面元素全部往后移动一位
                Array.Copy(keys,index,keys,index+1,_size-index);
                Array.Copy(values,index,values,index+1,_size-index);
            }
            keys[index] = key;      //插入元素
            values[index] = val;
            _size++;
        }
       //索引器
       public virtual K this[T key] {
            get {
                //查找指定元素
                int i = Array.BinarySearch(keys, 0, _size, key);
                if (i >= 0)
                {
                    return values[i];
                }
                return default(K);
            }
            set {
                //获取指定key的索引
                int i = Array.BinarySearch(keys, 0, _size, key);
                if (i >= 0)
                {
                    //如果key存在，则修改响应的values的值
                    values[i] = value;
                }
                else {
                    //如果不存在，执行插入操作
                    Insert(~i,key,value);
                }
            }
        }
        //删除操作
        public virtual bool Remove(T key) {
            //获取指定key的索引
            int index = Array.BinarySearch(keys, 0, _size, key);
            if (index >= 0 && index <_size)
            {
                Array.Copy(keys,index+1,keys,index,_size-index);
                Array.Copy(values,index+1,values,index,_size-index);
                _size--;
                return true;

            }
            return false;
        }
        //测试专用
        public override string ToString()
        {
            string s = string.Empty;
            for (int i = 0; i < _size; i++)
            {
                s += keys[i] + " " + values[i] + "\r\n";
            }
            return s;
        }
    }
}
