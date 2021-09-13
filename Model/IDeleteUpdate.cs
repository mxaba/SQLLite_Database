using System.Threading.Tasks;

namespace SQLLite_Database.Model
{
    public interface IDeleteUpdate
    {
        Task<string> Delete(EmailDelete email);
        Task Update(Coder Coder);
    }
}