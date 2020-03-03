using System;

namespace Binary_Trees
{

    /*
     * Tasks:
     * 1) Complete the implementation of the Node methods
     * 2) Print out the tree using the different tree traversal metods
     * 3) Test findNote() and deleteNode()
     *
     *
     */
    class Node
    {
        // Attributes
        private Node left = null;
        private Node right = null;
        private string item;

        //Methods
        private int toInt(string s)
        {
            int val = 0;
            foreach (char c in s)
            {
                val += c;
            }
            return val;
        }
        public Node(string item) 
        {
            this.item = item;
        }
        public void addNode(string item)
        {
            Node cur = this;
            while(true)
            {
                if (toInt(cur.item) <= toInt(item))
                {
                    if (cur.left == null)
                    {
                        cur.left = new Node(item);
                        return;
                    }
                    else
                    {
                        cur = cur.left;
                    }
                }
                else
                {
                    if (cur.right == null)
                    {
                        cur.right = new Node(item);
                        return;
                    }
                    else
                    {
                        cur = cur.right;
                    }
                }
            }
        }
        public Boolean findNode(string item) 
        {
            Node cur = this;
            while (true)
            {
                if (toInt(cur.item) <= toInt(item))
                {
                    if (cur.left == null)
                    {
                        return false;
                    }
                    else
                    {
                        if (cur.left.item == item)
                        {
                            return true;
                        }
                        cur = cur.left;
                    }
                }
                else
                {
                    if (cur.right == null)
                    {
                        return false;
                    }
                    else
                    {
                        if (cur.right.item == item)
                        {
                            return true;
                        }
                        cur = cur.right;
                    }
                }
            } 
        }
        public Boolean deleteNote(string item) 
        {
            Node cur = this;
            while (true)
            {
                if (toInt(cur.item) <= toInt(item))
                {
                    if (cur.left == null)
                    {
                        return false;
                    }
                    else
                    {
                        if (cur.left.item == item)
                        {
                            if (cur.left.left == null && cur.left.right == null)
                            {
                                cur.left = null;
                            }
                            else
                            {
                                Node temp = new Node(cur.left.left.item);
                                cur.left = temp;
                                cur = cur.left.left;
                                Node store = cur;
                                while (cur.left != null)
                                {
                                    temp.addNode(cur.left.item);
                                    cur = cur.left;
                                }
                                cur = store;
                                while (cur.right != null)
                                {
                                    temp.addNode(cur.right.item);
                                    cur = cur.right;
                                }
                            }
                            return true;
                        }
                        cur = cur.left;
                    }
                }
                else
                {
                    if (cur.right == null)
                    {
                        return false;
                    }
                    else
                    {
                        if (cur.right.item == item)
                        {
                            if (cur.right.left == null && cur.right.right == null)
                            {
                                cur.left = null;
                            }
                            else
                            {
                                Node temp = new Node(cur.right.right.item);
                                cur.right = temp;
                                cur = cur.right.right;
                                Node store = cur;
                                while (cur.right != null)
                                {
                                    temp.addNode(cur.right.item);
                                    cur = cur.right;
                                }
                                cur = store;
                                while (cur.left != null)
                                {
                                    temp.addNode(cur.left.item);
                                    cur = cur.left;
                                }
                            }
                            return true;
                        }
                        cur = cur.right;
                    }
                }
            } 
        }
        public void printTree()
        {

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Node root = null;

            string[] months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };


            // process all the nodes on the array
            //
            foreach (var mon in months)
            {
                if (root == null)
                    root = new Node(mon);
                else
                    root.addNode(mon);
            }

            // print out the tree using different traversal methods
            //
            root.printTree();
            // Test the findNote() and deleteNode()
        }
    }
}
