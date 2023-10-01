namespace Lab3;

public class DoublyNode<T>
{
    public T data;
    public DoublyNode<T> previous;
    public DoublyNode<T> next;
    public DoublyNode(T data){
        this.data = data;
    }
}
