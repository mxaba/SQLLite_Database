using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SQLLite_Database.Model;

namespace SQLLite_Database.Controllers
{
    [Route("api/getCoder/")]
    [ApiController]
    public class CoderQueryConroller : ControllerBase
    {
        private readonly ICoderByEmail CoderByEmail;
        private readonly ICoderRepository coderRepository;
 
        public CoderQueryConroller(ICoderByEmail CoderByEmail, ICoderRepository coderRepository)
        {
            this.CoderByEmail = CoderByEmail;
            this.coderRepository = coderRepository;
        }
 
        [HttpGet("Email/{Email}")]
        public async Task<IEnumerable<Coder>> GetByEmail([FromRoute]string Email)
        {
            return await CoderByEmail.GetByEmail(Email);
        }

        [HttpGet("EmailExplain/{Email}")]
        public async Task<IEnumerable<Coder>> GetByEmailExplain([FromRoute]string Email)
        {
            return await CoderByEmail.GetByEmailExplain(Email);
        }

        // [Route("api/Coder/id/{id}")]
        [HttpGet("IdNumber/{IdNumber}")]
        public async Task<IEnumerable<Coder>> GetById([FromRoute]string IdNumber)
        {
            return await CoderByEmail.GetById(IdNumber);
        }

        [HttpGet("IdNumberExplain/{IdNumber}")]
        public async Task<IEnumerable<Coder>> GetByIdExplain([FromRoute]string IdNumber)
        {
            return await CoderByEmail.GetById(IdNumber);
        }
 
 
        // POST api/<CodeController>
        // [HttpPost]
        // public async Task Post([FromBody] Coder coder)
        // {
        //     await coderRepository.Create(coder);
        // }
    }
}