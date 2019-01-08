using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeCostApi.Models
{
    public class College
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double InStateTution { get; set; }
        public double OutOfStateTution { get; set; }
        public double RoomBoardCost { get; set; }
    }
}
