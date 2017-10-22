using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using project.Services;
using project.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace project.Controllers
{
    [Route("api/[controller]")]
    [ValidateModel]
    public class EmployeeController : Controller
    {
        private readonly EmployeeServicesImpl services;
        private readonly EmployeeResposity employeeResposity;

        public object JObject { get; private set; }

        public EmployeeController()
        {
            employeeResposity = new EmployeeResposity();
            services = new EmployeeServicesImpl();

        }

        [HttpPost]
        [Route("/register")]
        public int register([FromBody] Employee emp)
        {
            // hash password 
            emp.password = services.hashPassword(emp.password);
            return employeeResposity.Add(emp);
        }
        [HttpPost]
        [Route("/login")]
        public string login([FromBody] Login user)
        {

            JObject obj = new JObject();
            obj["token"] = services.login(user);
            return JsonConvert.SerializeObject(obj);

        }
        [HttpGet]
        [Route("/userInfo/{accessToken}")]
        public Employee Get(string accessToken)
        {
            return services.getUserInfoByToken(accessToken);
        }
        [HttpPost]
        [Route("/changePassword")]
        public void changePassword([FromBody]NewPassword pass)
        {
            // get current user with old password and user name
            services.changePassword(pass);
        }
    }
}