using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using project.Entities;
using project.Middleware;

namespace project.Controllers
{
    [Route("api/[controller]")]
    [ValidateModel]
    public class ProducerController : Controller
    {
        private readonly ProducerRespository ProducerRespository;
        public ProducerController()
        {
            ProducerRespository = new ProducerRespository();
        }
        // GET: Producer/get
        [HttpGet]
        public IEnumerable<Producer> Get()
        {
            return ProducerRespository.GetAll();
        }

        // GET Producer/values/5
        [HttpGet("{id}")]
        public Producer Get(int id)
        {
            return ProducerRespository.GetById(id);
        }

        // POST Producer/values
        [HttpPost]
        public void Post([FromBody]Producer Producer)
        {
                ProducerRespository.Add(Producer);
        }

        // PUT Producer/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Producer Producer)
        {
            Producer.id = id;
            ProducerRespository.Update(Producer);
        }

        // DELETE Producer/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ProducerRespository.Delete(id);
        }
    }
}