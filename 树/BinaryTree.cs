using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 树
{
    class BinaryTree
    {
        private Node _head;     //头结点
        private string _cStr;       //构建二叉树的字符串

        public Node Head {
            get {
                return _head;
            }
        }
        //构造方法
        public BinaryTree(string constructStr) {
            _cStr = constructStr;       //保存构造字符串
            _head = new Node(_cStr[0]); //添加头结点
            Add(_head, 0);      //给头结点添加孩子节点
        }

        private void Add(Node parent, int index) {
            int leftIndex = 2 * index + 1;  //计算左孩子的索引
            int rightIndex = 2 * index + 2; //计算右孩子的索引
            if (leftIndex < _cStr.Length) {  //如果索引没有超过字符串的长度
                if(_cStr[leftIndex] != '#') { //# 表示空结点
                    parent.Left = new Node(_cStr[leftIndex]);
                    //递归调用Add方法添加左孩子的孩子节点
                    Add(parent.Left,leftIndex);
                }
            }
            if (rightIndex < _cStr.Length) {
                if (_cStr[rightIndex] != '#')
                {
                    parent.Right = new Node(_cStr[rightIndex]);
                    Add(parent.Right, rightIndex);
                }
            }
        }

        //先序遍历
        public void PreOrder(Node node) {
            if (node != null) {
                Console.Write(node.ToString());
                PreOrder(node.Left);    //递归左
                PreOrder(node.Right);   //递归右
            }
        }
        //中序遍历
        public void MidOrder(Node node) {
            if (node != null) {
                MidOrder(node.Left);
                Console.Write(node.ToString());
                MidOrder(node.Right);
            }
        }
        //后续遍历
        public void AfterOrder(Node node) {
            if (node != null) {
                AfterOrder(node.Left);
                AfterOrder(node.Right);
                Console.Write(node.ToString());
            }
        }
        //广度优先遍历
        public void LevelOrder() {
            Queue<Node> queue = new Queue<Node>();      //创建一个队列对象
            queue.Enqueue(_head);       //将根节点压入队列
            while (queue.Count > 0) {       //只要队列不为空
                Node node = queue.Dequeue();        //出队
                Console.Write(node.ToString());
                if (node.Left != null) {        //如果左孩子不为空
                    //将左孩子压入队列
                    queue.Enqueue(node.Left);
                }
                if (node.Right != null)//如果右孩子不为空
                {
                    //将右孩子压入队列
                    queue.Enqueue(node.Right);
                }
            }
        }
    }
}
