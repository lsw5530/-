using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 树
{
    class Node
    {
        //成员变量
        private object _data;       //数据
        private Node _left;     //左孩子
        private Node _right;       //右孩子
        public object Data {
            get {
                return _data;
            }
        }
        public Node Left {
            set {
                _left = value;
            }
            get {
                return _left;
            }
        }
        public Node Right {
            set {
                _right = value;
            }
            get {
                return _right;
            }
        }
        public Node(object data) {
            this._data = data;
        }
        public override string ToString()
        {
            return _data.ToString();
        }
    }
}
