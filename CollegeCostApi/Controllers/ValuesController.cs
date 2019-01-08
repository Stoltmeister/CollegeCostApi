using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollegeCostApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace CollegeCostApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public List<College> colleges;


        public ValuesController()
        {
            colleges = CollegeData.GetCollegesFromCSV("college_costs.csv");
        }         

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<College>> Get()
        {            
            return colleges;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }
        
    }
}
