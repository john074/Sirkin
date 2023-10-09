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
        else if(id > this.id)
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
        else
        {
            throw new Exception("This id is already used");
        }
    }

    public void Remove(int id)
    {
        BinTree<T> element = Find(this, id);
        BinTree<T> tempElement;
        if(element == this)
        {
            if(element.RightChild != null)
            {
                tempElement = element.RightChild; 
            }
            else
            {
                tempElement = element.LeftChild;
            }

            while(tempElement.LeftChild != null)
            {
                tempElement = tempElement.LeftChild;
            }

            Remove(tempElement.id);
            this.id = tempElement.id;
            this.data = tempElement.data;
            return;
        }

        if(element.LeftChild == null && element.RightChild == null && element.Parent != null)
        {
            if(element.Parent.LeftChild == element){
                element.Parent.LeftChild = null;
            }
            else if(element.Parent.RightChild == element)
            {
                element.Parent.RightChild = null;
            }
            return;
        }

        if(element.LeftChild != null && element.RightChild == null)
        {
            element.LeftChild.Parent = element.Parent;
            if(element.Parent.LeftChild == element){
                element.Parent.LeftChild = element.LeftChild;
            }
            else if(element.Parent.RightChild == element)
            {
                element.Parent.RightChild = element.LeftChild;
            }
            return;
        }

        if(element.LeftChild == null && element.RightChild != null)
        {
            element.RightChild.Parent = element.Parent;
            if(element.Parent.LeftChild == element){
                element.Parent.LeftChild = element.RightChild;
            }
            else if(element.Parent.RightChild == element)
            {
                element.Parent.RightChild = element.RightChild;
            }
            return;
        }

        if(element.LeftChild != null && element.RightChild != null)
        {
            tempElement = element.RightChild;

            while(tempElement.LeftChild != null)
            {
                tempElement = tempElement.LeftChild;
            }

            Remove(tempElement.id);
            if(element.Parent.LeftChild == element){
                element.Parent.LeftChild = tempElement;
            }
            else if(element.Parent.RightChild == element)
            {
                element.Parent.RightChild = tempElement;
            }
            tempElement.LeftChild = element.LeftChild;
            tempElement.RightChild = element.RightChild;
            return;
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
