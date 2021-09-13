using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SQLLite_Database.Model;

namespace SQLLite_Database.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class DeleteUpdateController : ControllerBase
    {
        private readonly IDeleteUpdate deleteUpdate;
        private readonly ICoderRepository coderRepository;
 
        public DeleteUpdateController(IDeleteUpdate deleteUpdate, ICoderRepository coderRepository)
        {
            this.deleteUpdate = deleteUpdate;
            this.coderRepository = coderRepository;
        }

        [HttpPost("Delete")]
        public async Task<string> DeleteUser([FromBody]EmailDelete email)
        {
            return await deleteUpdate.Delete(email);
        }
 
 
        // POST api/<CodeController>
        [HttpPut]
        public async Task UpdateUser([FromBody] Coder coder)
        {
            await deleteUpdate.Update(coder);
        }
    }
}