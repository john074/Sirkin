namespace Lab4;
class Program
{
    static void Main(string[] args)
    {
        BinTree<string> tree = new BinTree<string>(10, "Honda Civic", null);
        tree.Add(9, "Toyota Corolla");
        tree.Add(13, "Mitsubishi Lancer");
        tree.Add(6, "BMW e34");
        tree.Add(11, "Audi a6");
        tree.Add(14, "Toyota Caldina");
        tree.Add(7, "Nissan Sunny");
        tree.Add(4, "Porsche 911");
        tree.Add(12, "Ford Focus");
        tree.Add(20, "Shevrolet Camaro");
        tree.Add(25, "Nissan Skyline");
        tree.Add(17, "Kia Rio");

        tree.Remove(4);
        tree.Remove(13);
        tree.Print(tree, 0);
    }
}
