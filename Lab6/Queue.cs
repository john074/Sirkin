namespace Lab6;
class Queue<T>
{
    int first;
    int last;
    int size;
    int count;
    T[] values;

    public Queue(int size)
    {
        first = 0;
        last = -1;
        count = 0;
        this.size = size;
        values = new T[size];
    }

    public void add(T value)
    {
        if(count != size)
        {   
            if(last == size-1)
            {
                last = -1;
            }
            values[++last] = value;
            count++;
        }
        else
        {
            throw new Exception("Queue overflow");
        }
    }

    public T dequeue()
    {
        if(count != 0)
        {
            T data = values[first++];
            count--;
            if(first == size)
            {
                first = 0;
            }
            return data;
        }
        else
        {
            throw new Exception("Queue was empty");
        }
        
        
    }

    public void Print()
    {
        string ans = string.Empty;
        int pointer = first;
        int countLocal = count;
        while(countLocal != 0)
        {
            ans += values[pointer++] + " ";
            countLocal--;
            if(pointer == size)
            {
                pointer = 0;
            }
        }

        System.Console.WriteLine(ans);
    }

}