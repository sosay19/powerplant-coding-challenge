using Newtonsoft.Json.Linq;
using System.Xml.Linq;

namespace Engie_API
{
    public class Payload
    {
        public double load { get; set; }
        public Fuel fuels { get; set; }
        public List<Powerplant> powerplants { get; set; }
    }
}
