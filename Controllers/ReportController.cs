using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using project.Entities;

namespace project.Controllers
{
    [Route("api/[controller]")]

    public class ReportController : Controller
    {
        private readonly ReportRespository reportRespository;
        public ReportController(){
            reportRespository = new ReportRespository();
        }
        [HttpGet("{startDate}/{endDate}")]
        public IEnumerable<Report> Get(string startDate, string endDate ){
            return reportRespository.GetReport(startDate, endDate);
        }
    }

}
