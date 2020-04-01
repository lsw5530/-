using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 四则运算
{
    class TreeNode
    {
        //成员变量
        private bool _isOptr;       //是否为操作符
        private int _data;      //数据
        private TreeNode _left;     //左孩子
        private TreeNode _right;    //右孩子

        public TreeNode Left {
            set {
                _left = value;
            }
            get {
                return _left;
            }
        }
        public TreeNode Right
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

        public TreeNode(int data) {
            _isOptr = false;
            this._data = data;
        }
        public TreeNode(char data) {
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
