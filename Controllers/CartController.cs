using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using project.Middleware;
using project.Services;

namespace project.Controllers
{
    [Route("api/[controller]")]

    public class CartController : Controller
    {
        private readonly CartServices cartServices;
        public CartController()
        {
            cartServices = new CartServices();
        }
        // GET: Cart/get
        [HttpGet]
        public IEnumerable<Cart> Get()
        {
            return cartServices.getAllOrder();
        }

        // GET Cart/values/5
        [HttpGet("{id}")]
        public Cart Get(int id)
        {
            return cartServices.getOrder(id);
        }

        // POST Cart/values
        [HttpPost]
        public int Post([FromBody]Cart cart)
        {
                return cartServices.addOrder(cart);
        }

        // PUT Cart/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Cart order)
        {
            order.orderCode = id;
            cartServices.updateOrder(order);
        }

        // DELETE Cart/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cartServices.deleteOrder(id);
        }
    }
}