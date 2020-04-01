using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExprTree
{
    class Node
    {
        //成员变量
        private int _data;      //数据
        private Node _left;     //左孩子
        private Node _right;    //右孩子
        private bool _isOptr;   //是否为操作符
        public Node Left {
            set {
                _left = value;
            }
            get {
                return _left;
            }
        }
        public Node Right
        {
            set
            {
                _right = value;
            }
            get
            {
                return _right;
            }
        }
        public int Data
        {
            set
            {
                _data = value;
            }
            get
            {
                return _data;
            }
        }
        public bool IsOptr {
            get {
                return _isOptr;
            }
        }
        public Node(int data) {
            _isOptr = false;
            _data = data;
        }
        public Node(char data) {
            _isOptr = true;
            _data = data;
        }
        public override string ToString()
        {
            if (_isOptr)
            {
                return Convert.ToString((char)_data);
            }
            else {
                return _data.ToString();
            }
        }
    }
}
