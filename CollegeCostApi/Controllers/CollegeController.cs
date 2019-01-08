using System.Collections.Generic;
using CollegeCostApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static System.Net.WebRequestMethods;

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

        // GET api/values/(name)
        [HttpGet("{name}")]
        public ActionResult<double> GetTotalCostByName(string name)
        {
            College selectedCollege = new College();
            if (string.IsNullOrEmpty(name) || name == "true" || name == "false")
            {
                return NotFound("College Name Required");
            }
            foreach (College c in colleges)
            {
                if (c.Name == name)
                {
                    selectedCollege = c;
                }
            }
            if (selectedCollege.Name == null)
            {
                return NotFound("Error: College not Found");
            }
            double tuitionCost = selectedCollege.InStateTution + selectedCollege.RoomBoardCost;
            return tuitionCost;
        }

        [HttpGet("{name}/{includeRoomAndBoard}")]
        public ActionResult<double> GetCostWithRoomAndBoard(string name, string includeRoomAndBoard)
        {
            bool addRoomAndBoard = includeRoomAndBoard == "false" ? false : true;
            College selectedCollege = new College();
            if (string.IsNullOrEmpty(name))
            {
                throw new HttpListenerException(400, "College Name Required");
            }
            foreach (College c in colleges)
            {
                if (c.Name == name)
                {
                    selectedCollege = c;
                }
            }
            if (selectedCollege.Name == null)
            {
                return NotFound("Error: College not Found");
            }
            double tuitionCost = addRoomAndBoard ? selectedCollege.InStateTution + selectedCollege.RoomBoardCost : selectedCollege.InStateTution;
            return tuitionCost;
        }

    }
}
