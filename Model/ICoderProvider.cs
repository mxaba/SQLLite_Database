using System.Collections.Generic;
using System.Threading.Tasks;


namespace SQLLite_Database.Model
{
    public interface ICoderProvider
    {
        Task<IEnumerable<Coder>> Get();
    }
}