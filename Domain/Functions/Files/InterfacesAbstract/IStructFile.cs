using Domain.ModelOfSettings;

namespace Domain.Functions.Files.InterfacesAbstract
{
    public interface IStructFile<T> where T : class
    {
        void Read();
        T GetModel();
         
    }
}
