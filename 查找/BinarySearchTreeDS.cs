using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 查找
{
    class BinarySearchTreeDS
    {
        
        public Node rootNode;       //根节点

        private int count = 0;  //元素的个数

        public int Count {
            get {
                return count;
            }
        }
        public BinarySearchTreeDS(int[] sourceData) {
            for (int i = 0; i < sourceData.Length; i++)
            {
                Insert(sourceData[i]);
            }
        }
        //节点插入逻辑
        public void Insert(int i) {
            Node newNode = new Node(i);     //创建新节点
            if (rootNode == null)
            {
                //如果树为空，则插入根节点
                rootNode = newNode;
                count++;
            }
            else {
                Node parent;
                Node currentNode = rootNode;
                while (true) {
                    parent = currentNode;
                    if (newNode.data < currentNode.data)
                    {
                        currentNode = currentNode.left;
                        if (currentNode == null)
                        {
                            //插入叶子以后跳出循环
                            parent.left = newNode;
                            count++;
                            break;
                        }
                    }
                    else if (newNode.data > currentNode.data)
                    {
                        currentNode = currentNode.right;
                        if (currentNode == null)
                        {
                            //插入叶子以后跳出循环
                            parent.right = newNode;
                            count++;
                            break;
                        }
                    }
                }
            }
            
        }
        //使用中序输出排序
        public void InOrder(Node tempNode) {
            if (tempNode != null) {
                InOrder(tempNode.left);
                Console.Write(tempNode.data.ToString()+" ");
                InOrder(tempNode.right);
            }
        }
        //查找树里面的最小值
        public Node FindMin() {
            if (rootNode == null) {
                //如果是空树
                return null;
            }
            Node currNode = rootNode;
            while (currNode.left != null) {
                currNode = currNode.left;
            }
            return currNode;
        }
        //查找树里面的最大值
        public Node FindMax()
        {
            if (rootNode == null)
            {
                //如果是空树
                return null;
            }
            Node currNode = rootNode;
            while (currNode.right != null)
            {
                currNode = currNode.right;
            }
            return currNode;
        }

        //查找特定的值
        public Node Search(int i) {
            Node current = rootNode;
            while (true) {
                if (i < current.data)
                {
                    if (current.left == null)
                    {
                        break;
                    }
                    current = current.left;
                }
                else if (i > current.data)
                {
                    if (current.right == null)
                    {
                        break;
                    }
                    current = current.right;
                }
                else {
                    return current;
                }
            }

            if (current.data != i) {
                return null;
            }
            return current;
        }

        //删除结点操作
        public Node DeleteNode(int key) {
            if (rootNode == null) {
                return null;
            }
            Node current = rootNode;
            Node parent = rootNode;
            while (true)
            {
                if (key < current.data)
                {
                    if (current.left == null)
                    {
                        break;
                    }
                    parent = current;
                    current = current.left;
                }
                else if (key > current.data)
                {
                    if (current.right == null)
                    {
                        break;
                    }
                    parent = current;
                    current = current.right;
                }
                else
                {
                    break;
                }
            }

            //情况一，没有孩子
            if (current.right == null && current.left == null)
            {
                if (current == rootNode)
                {
                    rootNode = null;
                }
                else
                {
                    if (current.data > parent.data)
                    {
                        parent.right = null;
                    }
                    else
                    {
                        parent.left = null;
                    }
                }
            }
            //情况二，只有一个左孩子
            else if (current.left != null && current.right == null)
            {
                if (current.data < parent.data)
                {
                    parent.left = current.left;
                }
                else
                {
                    parent.right = current.left;
                }
            }
            //情况三，只有一个右孩子
            else if (current.left == null && current.right != null)
            {
                if (current.data < parent.data)
                {
                    parent.left = current.right;
                }
                else
                {
                    parent.right = current.right;
                }
            }
            //情况四，有左右两个孩子
            else {
                //temp为左子树里面的最大值结点
                Node temp = current.left;
                while (temp.right != null) {
                    temp = temp.right;
                }
                temp.right = current.right;
                temp.left = current.left;

                if (current == rootNode)
                {
                    rootNode = temp;
                }
                else {
                    //删除的是左孩子
                    if (current.data < parent.data)
                    {
                        parent.left = temp;
                    }
                    else
                    {
                        parent.right = temp;
                    }
                }
            }
            count--;
            return current;
        }
    }
}
