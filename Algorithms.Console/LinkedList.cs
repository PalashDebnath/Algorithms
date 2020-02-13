namespace Algorithms.Application
{
    public class DoublyLinkedList
    {
        public ListNode<int> head;
        public ListNode<int> tail;


        //Time Complexity: O(1)
        //Space Complexity: O(1)
        public void SetHead(ListNode<int> node)
        {
            if(head == null)
            {
                head = node;
                tail = node;
                return;
            }
            InsertBefore(head, node);            
        }

        //Time Complexity: O(1)
        //Space Complexity: O(1)
        public void SetTail(ListNode<int> node)
        {
            if(tail == null)
            {
                SetHead(node);
                return;
            }
            InsertAfter(tail, node);
        }

        //Time Complexity: O(1)
        //Space Complexity: O(1)
        public void InsertBefore(ListNode<int> referenceNode, ListNode<int> targetNode)
        {
            if(head == targetNode && tail == targetNode)
            {
                return;
            }
            Remove(targetNode);
            targetNode.next = referenceNode;
            targetNode.prev = referenceNode.prev;
            if(referenceNode.prev == null)
            {
                head = targetNode;
            }
            else
            {
                referenceNode.prev.next = targetNode;
            }
            referenceNode.prev = targetNode;
        }

        //Time Complexity: O(1)
        //Space Complexity: O(1)
        public void InsertAfter(ListNode<int> referenceNode, ListNode<int> targetNode)
        {
            if(head == targetNode && tail == targetNode)
            {
                return;
            }
            Remove(targetNode);
            targetNode.prev = referenceNode;
            targetNode.next = referenceNode.next;
            if(referenceNode.next == null)
            {
                tail = targetNode;
            }
            else
            {
                referenceNode.next.prev = targetNode;
            }
            referenceNode.next = targetNode;
        }

        //Time Complexity: O(n)
        //Space Complexity: O(1)
        public void InsertAtPosition(int position, ListNode<int> newNode)
        {
            if(position == 1)
            {
                SetHead(newNode);
                return;
            }
            ListNode<int> currentNode = head;
            int currentPosition = 1;
            while(currentNode != null && currentPosition != position)
            {
                currentNode = currentNode.next;
                currentPosition = currentPosition + 1;
            }
            if(currentNode == null)
            {
                SetTail(newNode);
            }
            else
            {
                InsertBefore(currentNode, newNode);
            }
        }

        //Time Complexity: O(n)
        //Space Complexity: O(1)
        public void RemoveNodesWithValue(int value)
        {
            ListNode<int> currentNode = head;
            while(currentNode != null)
            {
                ListNode<int> targetNode = currentNode;
                currentNode = currentNode.next;
                if(targetNode.value == value)
                {
                    Remove(targetNode);
                }
            }
        }

        //Time Complexity: O(1)
        //Space Complexity: O(1)
        public void Remove(ListNode<int> node)
        {
            if(node == head)
            {
                head = head.next;
            }
            if(node == tail)
            {
                tail = tail.prev;
            }
            UpdateNodeLinks(node);
        }

        //Time Complexity: O(n)
        //Space Complexity: O(1)
        public bool ContainNodeWithValue(int value)
        {
            ListNode<int> currentNode = head;
            while(currentNode != null)
            {
                if(currentNode.value == value)
                {
                    return true;
                }
                currentNode = currentNode.next;
            }
            return false;
        }

        //Time Complexity: O(1)
        //Space Complexity: O(1)
        private void UpdateNodeLinks(ListNode<int> node)
        {
            if(node.prev != null)
            {
                node.prev.next = node.next;
            }
            if(node.next != null)
            {
                node.next.prev = node.prev;
            }
            node.prev = null;
            node.next = null;
        }
    }

    public class ListNode<T>
    {
        public T value;
        public ListNode<T> prev;
        public ListNode<T> next;

        public ListNode(T value) 
        {
            this.value = value;
        }
    }
}