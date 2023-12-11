namespace Lab6;
class Program
{
    static void Main(string[] args)
    {
        System.Console.WriteLine("Stack:");
        Stack<int> myStack = new Stack<int>(5);
        System.Console.WriteLine(myStack.IsEmpty());

        for(int i=0; i<5; i++)
        {
            myStack.Push(i+10);
        }

        myStack.Print();
        System.Console.WriteLine(myStack.IsFull());
        System.Console.WriteLine(myStack.Top());
        myStack.pop();
        myStack.pop();
        System.Console.WriteLine(myStack.IsFull());
        System.Console.WriteLine(myStack.Top());
        myStack.Print();

        System.Console.WriteLine();
        System.Console.WriteLine("Queue:");
        Queue<int> queue = new Queue<int>(6);
        for(int i=0; i<10; i++)
        {
            queue.add(i+11);
            queue.add(i+12);
            queue.add(i+13);
            queue.add(i+14);
            System.Console.WriteLine(queue.dequeue());
            System.Console.WriteLine(queue.dequeue());
            System.Console.WriteLine(queue.dequeue());
            System.Console.WriteLine(queue.dequeue());
        }
        queue.Print();
    }
}
