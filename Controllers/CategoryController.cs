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
    public class CategoryController : Controller
    {
        private readonly CategoryRespository categoryRespository;
        public CategoryController()
        {
            categoryRespository = new CategoryRespository();
        }
        // GET: Category/get
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return categoryRespository.GetAll();
        }

        // GET Category/values/5
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return categoryRespository.GetById(id);
        }

        // POST Category/values
        [HttpPost]
        public void Post([FromBody]Category Category)
        {
                categoryRespository.Add(Category);
        }

        // PUT Category/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Category Category)
        {
            Category.id = id;
            categoryRespository.Update(Category);
        }

        // DELETE Category/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            categoryRespository.Delete(id);
        }
    }
}