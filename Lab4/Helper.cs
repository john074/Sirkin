namespace Lab4;

public class Helper<T>
{
    public Dictionary<int, List<T>> levels = new Dictionary<int, List<T>>();

    public void AddItem(int key, T value)
    {
        if(levels.ContainsKey(key))
        {
            levels[key].Add(value);
        }
        else
        {
            levels.Add(key, new List<T>{value});
        }
    }
}
