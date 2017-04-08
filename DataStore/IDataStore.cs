namespace DataStore
{
    public interface IDataStore
    {
        T Load<T>(string name);
        void Save<T>(T obj, string name);
    }
}