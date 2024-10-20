namespace DomainGeneral
{
    public interface IStructFile
    {
        public T Get<T>(string JsonFile) where T : class;
       

    }
}
