using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace project.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly ProductRepository productRepository;
        public ProductController()
        {
            productRepository = new ProductRepository();
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return productRepository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return productRepository.GetByID(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Product prod)
        {
                productRepository.Add(prod);
        }

        // PUT api/values/5 
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Product prod)
        {
            prod.ProductId = id;
            if (ModelState.IsValid)
                productRepository.Update(prod);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            productRepository.Delete(id);
        }
    }
}
