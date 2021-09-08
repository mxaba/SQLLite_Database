using System.Threading.Tasks;

namespace SQLLite_Database.Model
{
    public interface ICoderRepository
    {
        Task Create(Coder Coder);
    }
}