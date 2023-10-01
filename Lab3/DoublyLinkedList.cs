using System.Collections;

namespace Lab3;

public class DoublyLinkedList<T> : IEnumerable<T>
{
    DoublyNode<T> head;
    DoublyNode<T> tail;
    public int length = 0;

    public void Add(T data)
    {
        DoublyNode<T> newNode = new DoublyNode<T>(data);
        if(head == null)
        {
            head = newNode;
        }
        else
        {
            tail.next = newNode;
            newNode.previous = tail;
        }

        tail = newNode;
        length++;
    }

    public void RemoveByValue(T data, bool removeAll=false)
    {
        DoublyNode<T> current = head;

        while(current != null)
        {
            if(current.data.Equals(data))
            {   
                if(current.previous != null)
                {
                    current.previous.next = current.next;
                    current.next.previous = current.previous;
                    if(current.next == null)
                    {
                        tail = current.previous;
                    }
                    current = current.next;
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
            current = current.next;
        }
    }

    public void RemoveByIndex(int index)
    {
        if(index >= length){
            throw new Exception("Косяк с индексами");
        }
        DoublyNode<T> current = head;
        int count = 0;

        while(current != null)
        {
            if(count == index)
            {
                if(current.previous != null)
                {
                    current.previous.next = current.next;
                    if(current.next == null)
                    {
                        tail = current.previous;
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

        DoublyNode<T> current = head;
        DoublyNode<T> last = null;
        int count = 0;

        while(current != null)
        {
            if(count >= index && count < finish)
            {  
                if(current.previous != null)
                {
                    if(last == null){
                        last = current.previous;
                    }
                    
                    if(count + 1 == finish){
                        last.next = current.next;
                        current.next.previous = last;
                    }
                    count++;
                    current = current.next;
                    length--;
                    continue;
                }
                else
                {
                    head = head?.next;
                    head.previous = null;
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
            current = current.next;
        }
    }

    public void Insert(int index, T data)
    {
        if(index > length)
        {
            throw new Exception("Косяк с индексами");
        }

        if(index == length)
        {
            Add(data);
            return;
        }

        DoublyNode<T> current = head;
        int count = 0;

        while(count != index)
        {
            current = current.next;
            count++;
        }

        DoublyNode<T> newNode = new DoublyNode<T>(data);
        if(current.previous == null)
        {
            head = newNode;
            head.next = current;
            current.previous = newNode;
        }
        else
        {
            current.previous.next = newNode;
            newNode.next = current;
            newNode.previous = current.previous;
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

        if(index == length){
            foreach(T i in data)
            {
                Add(i);
            }
            return;
        }

        DoublyNode<T> current = head;
        int count = 0;

        while(count != index)
        {   
            current = current.next;
            count++;
        }

        foreach(T i in data)
        {
            DoublyNode<T> newNode = new DoublyNode<T>(i);
            if(current.previous == null)
            {   
                head.previous = newNode;
                head = newNode;
                head.next = current;
            }
            else
            {
                current.previous.next = newNode;
                newNode.next = current;
                newNode.previous = current.previous;
                current.previous = newNode;
            }
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
        DoublyNode<T> current = head;
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
        DoublyNode<T> current = head;
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
        DoublyNode<T> current = head;
        while(current != null)
        {
            yield return current.data;
            current = current.next;
        }
    }

}
