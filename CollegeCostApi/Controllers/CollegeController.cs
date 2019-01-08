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
    public class CollegeController : ControllerBase
    {
        public List<College> colleges;


        public CollegeController()
        {
            colleges = CollegeData.GetCollegesFromCSV("college_costs.csv");
        }         

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<College>> Get()
        {            
            return colleges;
        }

        // GET api/values/(name)
        [HttpGet("{name}")]
        public ActionResult<double> Get(string name)
        {
            College selectedCollege = new College();
            foreach (College c in colleges)
            {
                if (c.Name == name)
                {
                    selectedCollege = c;
                }
            }
            if (selectedCollege == null)
            {
                return NotFound();
            }
            double tuitionCost = selectedCollege.InStateTution + selectedCollege.RoomBoardCost;
            return tuitionCost;
        }
        
    }
}
