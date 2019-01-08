using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeCostApi.Models
{
    public class CollegeData
    {    

        public static List<College> GetCollegesFromCSV(string fileName)
        {
            List<College> colleges = new List<College>();

            if (System.IO.File.Exists(fileName))
            {
                var collegeData = System.IO.File.ReadAllLines(fileName)
                .Select(l => l.Split(',').Select(s => s.Trim()).ToArray())
                .Where(a => true);

                foreach (string[] entry in collegeData)
                {
                    College college = new College();
                    bool extraComma = entry.Count() > 4 ? true : false;
                    int nameIndex = 0;
                    int inStateTuitionIndex = extraComma ? 2 : 1;
                    int outOfStateTuitionIndex = extraComma ? 3 : 2;
                    int roomBoardIndex = extraComma ? 4 : 3;
                    

                    if (entry[nameIndex] == "College" || entry[nameIndex] == "")
                    {
                        continue;
                    }
                    college.Name = extraComma ? entry[nameIndex] + ", " + entry[nameIndex + 1] : entry[nameIndex];
                    college.InStateTution = 0;
                    college.OutOfStateTution = 0;
                    if (entry[inStateTuitionIndex] != "")
                    {
                        college.InStateTution = Double.Parse(entry[inStateTuitionIndex]);
                    }                    
                                        
                    if (entry[outOfStateTuitionIndex] != "")
                    {
                        college.OutOfStateTution = Double.Parse(entry[outOfStateTuitionIndex]);
                        if (college.InStateTution == 0)
                        {
                            college.InStateTution = college.OutOfStateTution;
                        }
                    }
                    college.RoomBoardCost = Double.Parse(entry[roomBoardIndex]);
                    colleges.Add(college);
                }
            }
            return colleges;
        }
        
    }
}
