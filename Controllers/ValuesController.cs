using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using project.Entities;

namespace project.Controllers
{
[Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IOptions<MyConfig> config;
        private readonly IOptions<Config> realConfig;

        public ValuesController(IOptions<MyConfig> config, IOptions<Config> RealConfig)

        {
            realConfig = RealConfig;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
          var x=  Request.HttpContext.Items["userInfo"];
            return new string[] { "value1", realConfig.Value.ConnectionString };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id) => config.Value.ApplicationName;

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
