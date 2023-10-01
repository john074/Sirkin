using System.Collections;

namespace Lab3;

public class LinkedList<T> : IEnumerable<T>
{
    Node<T> head;
    Node<T> tail;
    public int length = 0;

    public void Add(T data)
    {
        Node<T> newNode = new Node<T>(data);

        if(head == null)
        {
            head = newNode;
        }
        else
        {
            tail.next = newNode;
        }

        tail = newNode;
        length++;
    }

    public void RemoveByValue(T data, bool removeAll=false)
    {
        Node<T> current = head;
        Node<T> previous = null;

        while(current != null && current.data != null)
        {
            if(current.data.Equals(data))
            {
                if(previous != null)
                {
                    previous.next = current.next;
                    if(current.next == null)
                    {
                        tail = previous;
                    }
                    current = previous;
                }
                else
                {
                    head = head?.next;
                    if(head == null)
                    {
                        tail = null;
                    }
                    current = current.next;
                }

                length--;
                if(!removeAll)
                {   
                    return;
                }
                continue;
            }

            previous = current;
            current = current.next;
        }
    }

    public void RemoveByIndex(int index)
    {
        Node<T> current = head;
        Node<T> previous = null;
        int count=0;

        while(current != null && current.data != null)
        {
            if(count == index)
            {
                if(previous != null)
                {
                    previous.next = current.next;
                    if(current.next == null)
                    {
                        tail = previous;
                    }
                }
                else
                {
                    head = head?.next;
                    if(head == null)
                    {
                        tail = null;
                    }
                }

                length--;
            }

            previous = current;
            current = current.next;
            count++;
        }
    }

    public void RemoveByIndex(int index, int finish=0)
    {   
        if(index > length || finish > length)
        {
            throw new Exception("Косяк с индексами");
        }

        Node<T> current = head;
        Node<T> previous = null;
        Node<T> last = null;
        int count = 0;

        while(current != null && current.data != null)
        {
            if(count >= index && count < finish)
            {  
                if(previous != null)
                {
                    if(last == null){
                        last = previous;
                    }
                    
                    if(count + 1 == finish){
                        last.next = current.next;
                    }
                    count++;
                    current = current.next;
                    length--;
                    continue;
                }
                else
                {
                    head = head?.next;
                    current = current.next;
                    count++;
                    length--;
                    if(head == null)
                    {
                        tail = null;
                    }
                    continue;
                }
            }
            count++;
            previous = current;
            current = current.next;
        }
    }

    public void Insert(int index, T data)
    {
        if(index > length)
        {
            throw new Exception("Косяк с индексами");
        }

        Node<T> current = head;
        Node<T> previous = null;
        int count = 0;

        while(count != index)
        {
            previous = current;
            current = current.next;
            count++;
        }

        Node<T> newNode = new Node<T>(data);
        if(previous == null)
        {
            head = newNode;
            head.next = current;
        }
        else
        {
            previous.next = newNode;
            newNode.next = current;
        }
        if(index+1 == length){
            tail = current;
        }
        length++;        
    }

    public void Insert(int index, IEnumerable<T>data)
    {
        if(index > length)
        {
            throw new Exception("Косяк с индексами");
        }

        Node<T> current = head;
        Node<T> previous = null;
        int count = 0;

        while(count != index)
        {
            previous = current;
            current = current.next;
            count++;
        }

        foreach(T i in data)
        {
            Node<T> newNode = new Node<T>(i);
            if(previous == null)
            {
                head = newNode;
                head.next = current;
            }
            else
            {
                previous.next = newNode;
                newNode.next = current;
            }
            previous = newNode;
            current = newNode.next;
            length++;
        }        
    }

    public void Clear()
    {
        head = null;
        tail = null;
        length = 0;
    }

    public T GetItemAtIndex(int index)
    {   
        Node<T> current = head;
        int count = 0;
        while(count != index)
        {
            current = current.next;
            count++;
        }
        return current.data;
    }

    public void SetItemAtIndex(int index, T data)
    {   
        Node<T> current = head;
        int count = 0;
        while(count != index)
        {
            current = current.next;
            count++;
        }
        current.data = data;
    }

    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable<T>)this).GetEnumerator();
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        Node<T> current = head;
        while(current != null)
        {
            yield return current.data;
            current = current.next;
        }
    }

}
