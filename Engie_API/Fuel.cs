using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Engie_API
{
    public class Fuel
    {

        [JsonPropertyName("gas(euro/MWh)")]
        public double gas { get; set; }

        [JsonPropertyName("kerosine(euro/MWh)")]
        public double kerosine { get; set; }

        [JsonPropertyName("co2(euro/ton)")]
        public double co2 { get; set; }

        [JsonPropertyName("wind(%)")]
        public double wind { get; set; }
    }
}