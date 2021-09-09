using System.Collections.Generic;
using System.Threading.Tasks;


namespace SQLLite_Database.Model
{
    public interface ICoderByEmail
    {
        Task<IEnumerable<Coder>> GetByEmail(string email);
        Task<IEnumerable<Coder>> GetById(string email);
        Task<IEnumerable<Coder>> GetByEmailExplain(string email);
        Task<IEnumerable<Coder>> GetByIdExplain(string email);
    }
}