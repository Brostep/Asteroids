public interface IPoolable<T>
{
    void InitializeObject(T obj);

    void Initialize();

    void DiscardObject(T obj);
}
