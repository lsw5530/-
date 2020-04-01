using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 查找
{
    class Node
    {
        public Node left;       //左孩子指针
        public Node right;      //右孩子指针
            
        public int data;        //数据

        public string md5;      //用于测试的数据
        public Node(int _data) {
            this.data = _data;
            this.md5 = _data + "hello";
        }

        public override string ToString()
        {
            return data.ToString();
        }

    }
}
