namespace DomainGeneral
{
    public interface IStructFile
    {
        T Read<T>(string path) where T : class;
       

    }
}
