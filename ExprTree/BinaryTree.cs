using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExprTree
{
    class BinaryTree
    {
        //成员变量
        private Node _head;     //头指针
        private string expStr;      //表达式字符串
        private int pos = 0;        //解析字符串当前位置

        public BinaryTree(string constructStr) {
            this.expStr = constructStr;
            CreateTree();
        }
        //创建表达式的树
        public void CreateTree() {
            while (pos < expStr.Length) {
                Node node = GetNode();
                if (_head == null)
                {
                    //根节点不存在，第一个结点就为根
                    _head = node;
                }
                else if (!_head.IsOptr)
                {
                    //若根节点为数字，当前节点为根，之前的根变为左孩子
                    node.Left = _head;
                    _head = node;
                }
                else if (!node.IsOptr)
                {
                    //当前节点为数字
                    Node tempNode = _head;
                    while (tempNode.Right != null)
                    {
                        tempNode = tempNode.Right;
                    }
                    tempNode.Right = node;
                }
                else {
                    if (GetPriority((char)node.Data) <= GetPriority((char)_head.Data)) {
                        //优先级不高时，新结点成为根结点，原表达式成为新结点的左子树
                        node.Left = _head;
                        _head = node;
                    }
                    else {
                        //优先级高时，新结点成为根结点的右孩子，原根结点的右孩子成为新结点的左子树
                        node.Left = _head.Right;
                        _head.Right = node;
                    }
                }
            }
        }
        //创建节点
        private Node GetNode() {
            char ch = expStr[pos];      //获取当前解析的字符
            if (char.IsDigit(ch))        //判断当前字符是否为数字
            {
                //若操作的数字大于1位，需要用循环获取
                StringBuilder numStr = new StringBuilder();
                while (pos < expStr.Length && char.IsDigit(ch = expStr[pos])) {
                    pos++;
                    numStr.Append(ch);
                }
                return new Node(Convert.ToInt32(numStr.ToString()));
            }
            else {      //为操作符
                pos++;
                return new Node(ch);
            }
        }
        //获取运算符的优先级,乘除优先级要高于加减
        private int GetPriority(char optr) {
            if (optr == '+' || optr == '-')
            {
                return 1;
            }
            else if (optr == '*' || optr == '/')
            {
                return 2;
            }
            else {
                return 0;
            }
        }
        private int PreOrderCalc(Node node) {
            int n1, n2;
            if (node.IsOptr) {
                //先遍历计算表达式的结果
                n1 = PreOrderCalc(node.Left);
                n2 = PreOrderCalc(node.Right);
                char optr = (char)node.Data;
                switch (optr) {
                    case '+':
                        node.Data = n1 + n2;
                        break;
                    case '-':
                        node.Data = n1 - n2;
                        break;
                    case '*':
                        node.Data = n1 * n2;
                        break;
                    case '/':
                        node.Data = n1 / n2;
                        break;
                }
            }
            return node.Data;
        }
        //获取四则运算的值
        public int GetResult() {
            return PreOrderCalc(_head);
        }
    }
}
