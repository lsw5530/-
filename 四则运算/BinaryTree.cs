using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 四则运算
{
    class BinaryTree
    {
        //成员变量
        private TreeNode _head;     //头指针
        private string expStr;      //用于构造二叉树的表达式字符串

        private int pos = 0;        //当前解析的字符的位置

        public BinaryTree(string constructStr) {
            this.expStr = constructStr;
            //赋值 _head
        }
        public void CreateTree() {
            TreeNode head = null;
            while (pos < expStr.Length) {
                TreeNode tempNode;      //临时结点
                char ch = expStr[pos];
                //判断字符是否为数字
                if (char.IsDigit(ch))
                {
                    tempNode = new TreeNode(Convert.ToInt32(ch));
                }
                else {
                    tempNode = new TreeNode(ch);
                }
                if (head == null)
                {
                    //如果根节点不存在
                    head = tempNode;
                }
                else if (!head.IsOptr)
                {//根节点为数字，新节点变为根结点，原来的根变为新节点的左子树
                    tempNode.Left = head;
                    head = tempNode;
                }
                else if (!tempNode.IsOptr)
                {    //当前为数字的时候
                    TreeNode node = head;
                    while (node.Right != null)
                    {
                        node = node.Right;
                    }
                    node.Right = tempNode;
                }
                else {
                    //比较优先级

                }
            }
        }

    }
}
