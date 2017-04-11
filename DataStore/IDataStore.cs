namespace DataStore
{
    public interface IDataStore
    {
        string FilePath { get; set; }

        T Load<T>(string name);
        void Save<T>(T obj, string name);
    }
}