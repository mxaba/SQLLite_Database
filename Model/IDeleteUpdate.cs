using System.Threading.Tasks;

namespace SQLLite_Database.Model
{
    public interface IDeleteUpdate
    {
        Task<int> Delete(string Email);
        Task Update(Coder Coder);
    }
}