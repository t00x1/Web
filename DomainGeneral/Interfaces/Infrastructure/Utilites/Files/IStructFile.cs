namespace DomainGeneral.Interfaces.Infrastructure.Utilites.Files
{
    public interface IStructFile<T> where T : class
    {
        void Read();
        T Model { get; }

    }
}
