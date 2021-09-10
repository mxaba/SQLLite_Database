using System.Threading.Tasks;

namespace SQLLite_Database.Model
{
    public interface IDeleteUpdate
    {
        Task<string> Delete(string Email);
        Task Update(Coder Coder);
    }
}