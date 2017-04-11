namespace tIDE.Plugin.Interface
{
    public interface IToolBarCollection
    {
        IToolBar Add(string id);
        void Remove(IToolBar toolBar);
        void Clear();

        IToolBar this[string id] { get; }
        IToolBar this[int index] { get; }
    }
}