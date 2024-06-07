namespace alg
{
    class Node
    {
        public int value;
        public Node left;
        public Node right;
        public Node parent;
        public Node(int v = 0)
        {
            value = v;
            left = null;
            right = null;
            parent = null;
        }
    }
    class Tree
    {
        public Node rishe;
        public Tree(Node rishe = null)
        {
            this.rishe = rishe;
        }
        private Node Insert(Node rishe, int v)
        {
            if (rishe == null)
            {
                rishe = new Node(v);
                return rishe;
            }
            if (v < rishe.value)
                rishe.left = Insert(rishe.left, v);
            else if (v > rishe.value)
                rishe.right = Insert(rishe.right, v);
            return rishe;
        }
        public void insert(int v)
        {
            rishe = Insert(rishe, v);
        }
        private Node Remove(int v, Node vorudi)
        {
            if (vorudi == null)
                return vorudi;
            else if (v < vorudi.value)
                rishe.left = Remove(v, vorudi.left);
            else if (v > vorudi.value)
                rishe.right = Remove(v, vorudi.right);
            else
            {
                if (vorudi.left == null)
                    return vorudi.right;
                else if (vorudi.right == null)
                    return vorudi.left;
                vorudi.value = MinValue(vorudi.right);
                vorudi.right = Remove(vorudi.value, vorudi.right);
            }
            return vorudi;
        }
        public int MinValue(Node vorudi)
        {
            int minv = vorudi.value;
            while (vorudi.left != null)
            {
                minv = vorudi.left.value;
                vorudi = vorudi.left;
            }
            return minv;
        }
        public void remove(int v)
        {
            rishe = Remove(v, rishe);
        }
        public Node previous(Node vorudi)
        {
            if (vorudi == null)
                return null;
            if (vorudi.left != null)
            {
                return findmax(vorudi.left);
            }
            Node previousnode = null;
            Node current = rishe;
            while (current != null)
            {
                if (vorudi.value > current.value)
                {
                    previousnode = current;
                    current = current.right;
                }
                else if (vorudi.value < current.value)
                {
                    current = current.left;
                }
                else
                    break;
            }
            return previousnode;
        }
        public Node findmax(Node vorudi)
        {
            while (vorudi.right != null)
            {
                vorudi = vorudi.right;
            }
            return vorudi;
        }

        public Node next(Node vorudi)
        {
            if (vorudi == null)
            {
                return null;
            }
            if (vorudi.right != null)
            {
                return findmin(vorudi.right);
            }
            Node nextnode = vorudi.parent;
            Node current = rishe;
            while (current !=null)
            {
                if (vorudi.value < current.value)
                {
                    nextnode = current;
                    current = current.left;
                }
                else if(vorudi.value > current.value)
                {
                    current = current.right; 
                }
                else
                    break;
            }
            return nextnode;
        }
        public Node findmin(Node vorudi)
        {
            while (vorudi.left != null)
            {
                vorudi = vorudi.left;
            }
            return vorudi;
        }
        private void Inorderadd(Node vorudi, List<int> result)
        {
            if (vorudi == null)
                return;
            else
            {
                Inorderadd(vorudi.left, result);
                result.Add(vorudi.value);
                Inorderadd(vorudi.right, result);
            }
        }  
        private List<int> mergelists(List<int> vorudi1, List<int> vorudi2)
        {
            List<int> mergedlist = new List<int>();
            int i = 0;
            int j = 0;
            while (i < vorudi1.Count && j < vorudi2.Count)
            {
                if (vorudi1[i] < vorudi2[j])
                {
                    mergedlist.Add(vorudi1[i++]);
                }
                else
                {
                    mergedlist.Add(vorudi2[j++]);
                }
            }
            while (i < vorudi1.Count)
            {
                mergedlist.Add(vorudi1[i++]);
            }
            while (j < vorudi2.Count)
            {
                mergedlist.Add(vorudi2[j++]);
            }
            return mergedlist;
        }
        public Node sorttobst(List<int> mergedlist, int start, int end)
        {
            if (start > end)
                return null;
            int vasat = (start + end) / 2;
            Node komaki = new Node(mergedlist[vasat]);
            komaki.left = sorttobst(mergedlist, start, vasat - 1);
            komaki.right = sorttobst(mergedlist, vasat + 1, end);
            return komaki;
        }
        public Node mergebsts(Node vorudi1, Node vorudi2)
        {
            List<int> bst1 = new List<int>();
            List<int> bst2 = new List<int>();
            Inorderadd(vorudi1, bst1);
            Inorderadd(vorudi2, bst2);
            List<int> mergedlist = mergelists(bst1,bst2);
            return sorttobst(mergedlist, 0, mergedlist.Count - 1);
        }
        public static void Inorderwriteline(Node vorudi)
        {
            if (vorudi != null)
            {
                Inorderwriteline(vorudi.left);
                Console.Write(vorudi.value + " ");
                Inorderwriteline(vorudi.right);
            }
        }
    }
    class person
    {
        public int age;
        public List<string> skill = new List<string> { "A", "B", "C", "D", "E", "F" };
    }
    class heap
    {
        public int size;
        public List<int> list;
        public int parent(int i) => (i - 1) / 2;
        public heap(List<int> list1)
        {
            list = list1;
            size = list.Count;
        }
        public void maxhipify(int vorudi)
        {
            int largest = vorudi;
            int left = 2 * vorudi + 1;
            int right = 2 * vorudi + 2;
            if (largest < size && list[left] > list[largest])
            {
                largest = left;
            }
            if (right < size && list[right] > list[largest])
            {
                largest = right;
            }
            if (largest != vorudi)
            {
                swap(vorudi, largest);
                maxhipify(list[largest]);
            }
        }
        public void swap(int vorudi1, int vorudi2)
        {
            {
                int i = list[vorudi1];
                list[vorudi1] = list[vorudi2];
                list[vorudi2] = i;
            }
        }
        public void buildmaxheap()
        {
            for (int i = size / 2; i >= 0; i--)
            {
                maxhipify(list[i]);
            }
        }
        public void increasekey(int vorudi, int newkey)
        {
            if (newkey < list[vorudi])
            {
                throw new ArgumentException("kelid jadid az ghabli kuchak tar mibashad");
            }
            list[vorudi] = newkey;
            while (vorudi > 0 && list[parent(vorudi)] < list[vorudi])
            {
                swap(vorudi, list[parent(vorudi)]);
                vorudi = list[parent(vorudi)];
            }
        }
        public void insertnewkey(int vorudi)
        {
            list.Add(vorudi);
            maxhipify(list.Count -1);
        }
        public int extractmax()
        {
            if (size <= 0)
                throw new InvalidOperationException("heap is empty");
            buildmaxheap();
            int max = list[0];
            list[0] = list[list.Count - 1];
            list.RemoveAt(list.Count -1);
            maxhipify(0);
            return max;
        }
        public void print()
        {
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" which?");
            Console.WriteLine("1 = remove");
            Console.WriteLine("2 = insert");
            Console.WriteLine("3 = find previous");
            Console.WriteLine("4 = find next");
            Console.WriteLine("5 =  merge");
            Console.WriteLine("6 =  get input , extract from largest nodes as many as input then insert in maxheap");
            Console.WriteLine("7 =  insert member");
            Console.WriteLine("8 =  increase value");
            Console.WriteLine("9 =  extract max");
            Console.WriteLine("10 =  print heap");
            int k = Convert.ToInt32(Console.ReadLine());
            Node rishe1 = new Node(20);
            Node node10 = new Node(10);
            Node node30 = new Node(30);
            Node node5 = new Node(5);
            Node node15 = new Node(15);

            rishe1.left = node10;
            rishe1.right = node30;
            node10.parent = rishe1;
            node30.parent = rishe1;
            node10.left = node5;
            node10.right = node15;
            node5.parent = node10;
            node15.parent = node10;

            Node rishe2 = new Node(60);
            Node node50 = new Node(50);
            Node node70 = new Node(70);
            
            rishe2.left = node50;
            rishe2.right = node70;

            Tree tree1 = new Tree(rishe1);
            Tree tree2 = new Tree(rishe2);
            Tree tree3 = new Tree();
            List<int>  mmd = new List<int>() {30,25,20,15,10};
            heap nnn = new heap(mmd);
            switch (k)
            {
                case 1:
                    {
                        Console.WriteLine(" what is input?");
                        int w = Convert.ToInt32(Console.ReadLine());
                        tree1.remove(w);
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine(" what is input?");
                        int w = Convert.ToInt32(Console.ReadLine());
                        tree1.insert(w);
                        break;
                    }
                case 3:
                    {
                        Node prevoius = tree1.previous(node10);
                        if (prevoius != null)
                        {
                            Console.WriteLine(prevoius.value);
                        }
                        else
                        {
                            Console.WriteLine("node  has no inorder prevoius");
                        }
                        break;
                    }
                case 4:
                    {
                        Node next = tree1.next(rishe1);
                        if (next != null)
                        {
                            Console.WriteLine(next.value);
                        }
                        else
                        {
                            Console.WriteLine("node  has no inorder prevoius");
                        }
                        break;
                    }
                case 5:
                    {
                        Node combined = tree3.mergebsts(rishe1, rishe2);
                        Tree.Inorderwriteline(combined);
                        break;
                    }
                case 6:
                    {
                        Console.WriteLine("how many ? ");
                        int zzz = Convert.ToInt32(Console.ReadLine());
                        extractmaxandinsertinheap(rishe1, zzz, nnn);
                        nnn.print();
                        break;
                    }
                case 7:
                    {
                        Console.WriteLine("new key ");
                        int case7 = Convert.ToInt32(Console.ReadLine());
                        nnn.insertnewkey(case7);
                        nnn.print();
                        break;
                    }
                case 8:
                    {
                        Console.WriteLine("which node ");
                        int iman = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("new value ");
                        int case8 = Convert.ToInt32(Console.ReadLine());
                        nnn.increasekey(iman, case8);
                        nnn.print();
                        break;
                    }
                case 9:
                    {
                        nnn.extractmax();
                        nnn.print();
                        break;
                    }
                case 10:
                    {
                        nnn.print();
                        break;
                    }
            }
        }
        public static void extractmaxandinsertinheap(Node rishe, int vorudi, heap maxheap)
        {
            if (rishe == null && vorudi <= 0)
                return;
            Stack<Node> stack = new Stack<Node>();
            Node current = rishe;
            int count = vorudi;
            while (stack.Count > 0 || current != null)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.right;
                }
                current = stack.Pop();
                maxheap.insertnewkey(current.value);
                count++;
                if (count >= vorudi)
                    break;
                current = current.left;
            }
        }
    }
}