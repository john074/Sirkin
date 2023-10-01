using System.Reflection.Metadata.Ecma335;

namespace Lab4;

public class BinTree<T>
{
    public int id;
    public int lvl;
    public T data;
    public BinTree<T> RightChild;
    public BinTree<T> LeftChild;
    public BinTree<T> Parent;

    public BinTree(int id, T data, BinTree<T> Parent, int lvl=0)
    {
        this.id = id;
        this.data = data;
        this.Parent = Parent;
        this.lvl = lvl;
    }

    public void Add(int id, T data)
    {

        if(id < this.id)
        {
            if(LeftChild == null)
            {
                LeftChild = new BinTree<T>(id, data, this, lvl+1);
            }
            else
            {
                LeftChild.Add(id, data);   
            }
        }
        else
        {
            if(RightChild == null)
            {
                RightChild = new BinTree<T>(id, data, this, lvl+1);
            }
            else
            {
                RightChild.Add(id, data);
            }
        }
    }

    public BinTree<T> Find(BinTree<T> element, int id)
    {
        if(element == null)
        {
            return null;
        }
        if(element.id == id){
            return element;
        }
        else if(element.id < id){
            return Find(element.RightChild, id);
        }
        else if(element.id > id)
        {
            return Find(element.LeftChild, id);
        }

        return null;
    }

    public BinTree<T> FindByValue(BinTree<T> element, T data)
    {
        if(element == null)
            return null;

        if(element.data.Equals(data)){
            return element;
        }
        BinTree<T> left = FindByValue(element.LeftChild, data);
        BinTree<T> right = FindByValue(element.RightChild, data);

        return left == null ? right : left;
    }

    public void Print(BinTree<T> root, int space)
    {
        if(root == null)
            return;

        space += 13;
        Print(root.RightChild, space);
        Console.WriteLine();
        for(int i = 10; i< space; i++)
            System.Console.Write(" ");
        System.Console.WriteLine(root.data);
        Print(root.LeftChild, space);
    }
}
