using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SQLLite_Database.Model;

namespace SQLLite_Database.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoderController : ControllerBase
    {
        private readonly ICoderProvider coderProvider;
        private readonly ICoderRepository coderRepository;
 
        public CoderController(ICoderProvider coderProvider, ICoderRepository coderRepository)
        {
            this.coderProvider = coderProvider;
            this.coderRepository = coderRepository;
        }
 
        // GET: api/<CodeController>
        [HttpGet]
        public async Task<IEnumerable<Coder>> Get()
        {
            return await coderProvider.Get();
        }
 
 
        // POST api/<CodeController>
        [HttpPost]
        public async Task Post([FromBody] Coder coder)
        {
            await coderRepository.Create(coder);
        }
    }
}