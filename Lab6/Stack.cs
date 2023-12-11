namespace Lab6;
class Stack<T>
{
    T[] values;
    int top;
    int size;

    public Stack(int size)
    {
        this.size = size;
        top = -1;
        values = new T[size];
    }

    public void Push(T value)
    {
        try
        {
            values[++top] = value;
        }
        catch(IndexOutOfRangeException)
        {
            throw new StackOverflowException();
        }
    }

    public T pop()
    {
        try
        {
            return values[top--];
        }
        catch(IndexOutOfRangeException)
        {
            throw new Exception("Stack was empty");
        }
    }

    public bool IsFull()
    {
        return size-1 == top;
    }

    public bool IsEmpty()
    {
        return top == -1;
    }

    public T Top()
    {
        return IsEmpty() ? throw new Exception("Stack was empty") : values[top];
    }

    public void Print()
    {
        string ans = string.Empty;
        for(int i=0; i<=top; i++)
        {
            ans += values[i] + " ";
        }
        System.Console.WriteLine(ans);
    }

}