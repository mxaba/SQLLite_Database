using System.Collections.Generic;
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

        [HttpGet("Delete/{Email}")]
        public async Task<string> Delete([FromRoute]string email)
        {
            return await deleteUpdate.Delete(email);
        }
 
 
        // POST api/<CodeController>
        // [HttpPost]
        // public async Task Post([FromBody] Coder coder)
        // {
        //     await coderRepository.Create(coder);
        // }
    }
}