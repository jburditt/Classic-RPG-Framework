namespace DataStore
{
    public interface IDataStore
    {
        T Load<T>(string name) where T : new();
        void Save<T>(T obj, string name);
    }
}