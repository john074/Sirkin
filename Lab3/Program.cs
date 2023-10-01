namespace Lab3;
class Program
{
    static void Main(string[] args)
    {
        int[] names = {1, 2, 3, 4, 5};
        DoublyLinkedList<int> n = new DoublyLinkedList<int>();

        foreach(int i in names){
            n.Add(i);
        }

        n.Insert(0, 101);
        n.Insert(n.length-1, 404);
        n.Insert(1, new int[]{102, 104, 104});
        n.Insert(n.length, new int[]{-1, -2, -3});
        n.RemoveByValue(104, true);
        n.RemoveByIndex(n.length-1);
        n.SetItemAtIndex(1, 103);
        n.RemoveByIndex(3, 6);


        foreach(int i in n){
            Console.WriteLine(i);
        }

    }
}
