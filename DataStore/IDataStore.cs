namespace DataStore
{
    public interface IDataStore
    {
        T Load<T>(string name);
    }
}