using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using project.Middleware;

namespace project.Controllers
{
    [Route("api/[controller]")]

    public class CartController : Controller
    {
        private readonly CartRespository cartRespository;
        public CartController()
        {
            cartRespository = new CartRespository();
        }
        // GET: Cart/get
        [HttpGet]
        public IEnumerable<Cart> Get()
        {
            return cartRespository.getAll();
        }

        // GET Cart/values/5
        [HttpGet("{id}")]
        public Cart Get(int id)
        {
            return cartRespository.GetByID(id);
        }

        // POST Cart/values
        [HttpPost]
        public void Post([FromBody]Cart cart)
        {
            if (ModelState.IsValid)
                cartRespository.Add(cart);
        }

        // PUT Cart/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Cart cart)
        {
            cart.orderCode = id;
            if (ModelState.IsValid)
                cartRespository.Update(cart);
        }

        // DELETE Cart/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cartRespository.Delete(id);
        }
    }
}