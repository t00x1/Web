namespace DomainGeneral
{
    public interface IStructFile<T> where T : class
    {
        void Read();
        T Model { get; }

    }
}
