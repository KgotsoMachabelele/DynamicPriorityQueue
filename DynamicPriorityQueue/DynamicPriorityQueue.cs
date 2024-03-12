namespace DynamicPriorityQueue
{
    class DynamicPriorityQueue<T> : IQueue<T>
    {
        #region Private embedded class for individual nodes in the list
        private class Node
        {
            public int priority { get; private set; }
            public T element { get; private set; }
            public Node Next { get; set; } //Recursive definition

            //Constructor
            public Node(T element, int priority)
            {
                this.priority = priority;
                this.element = element;
                Next = null;
            }
        } //embedded class Node
        #endregion Embedded class
        
        #region private data members of the list
        private Node head;
        #endregion

        #region Property for count
        public int Count { get; private set; } //Count
        #endregion

        #region Constructor
        //Constructor for the list
        public DynamicPriorityQueue()
        {
            this.head = null;
            //this.tail = null;
            this.Count = 0;
        } //Constructor
        #endregion
        
        #region Queue operations

        public void Enqueue(T item, int priority)
        {
            Node newNode = new Node(item, priority);
            if (this.head == null) //Empty queue - this is the first element to be added
                this.head = newNode;
            else
            {
                //Step through existing nodes and find position of new node.
                Node prev = null, current = head;
                while (current != null && current.priority <= newNode.priority)
                {
                    prev = current;
                    current = current.Next;
                }

                //Insert new node between prev and current
                if (prev != null)
                    prev.Next = newNode;
                else //New node goes to the front
                    head = newNode;
                newNode.Next = current;
            } //else
            Count++;

        } //Enqueue

        public void Clear()
        {
            head = null;
            Count = 0;
        } //Clear

        public T Dequeue()
        {
            if (head != null)
            {
                T item = head.element;
                head = head.Next;
                Count--;
                return item;
            }
            return default(T);
        } //Dequeue

        public T Peek()
        {
            if (head != null)
                return head.element;
            else
                return default(T);
        } //Peek

        public bool Contains(T item)
        {
            Node current = head;
            while (current != null)
            {
                if (object.Equals(current.element, item))
                    return true;
                else
                    current = current.Next;
            }
            return false;
        } //Contains

        public int Position(T item)
        {
            Node current = head;
            int i = 0;
            while (current != null)
            {
                if (object.Equals(current.element, item))
                    return i;
                else
                {
                    current = current.Next;
                    i++;
                }
            }
            return -1;

        } //Position

        #endregion Queue operations

    } //class DynamicPriorityQueue

    public interface IQueue<T>
    {
        void Enqueue(T value, int priority);
        void Clear();
        T Dequeue();
        T Peek();
        bool Contains(T item);
        int Position(T item);
    } //interface

} //namespace
