using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ismétlés
{
    internal class Model
    {
        public List<Plane>planes = new List<Plane>();
        public void Import()
        {
            planes = File.ReadAllLines("plane.txt").Select(x => x.Split(";")).Select(x => new Plane  { PlaneId = Convert.ToInt32(x[0]), PlaneName = x[1], Capacity = Convert.ToInt32(x[2]), MaxSpeed = Convert.ToInt32(x[3]), BuiltYear = Convert.ToInt32(x[4]), TypeId = Convert.ToInt32(x[5]) }).ToList();
        }

    }
    public class Plane
    {
        public int PlaneId { get; set; }
        public string PlaneName { get; set; }
        public int Capacity { get; set; }
        public int MaxSpeed { get; set; }
        public int BuiltYear { get; set; }
        public int TypeId { get; set; }
    }

    public class PlaneType
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; }
    }
}
