namespace Engie_API
{

    public class Powerplant
    {
        public string? name { get; set; }
        public string type { get; set; }
        public double efficiency { get; set; }
        public int pmax { get; set; }
        public int pmin { get; set; }
        public double current_load { get; set; }
        public double cost { get; set; }
        public double pmax_cost { get; set; }

        public void powerProduced()
        {

        }

        internal void set_pmax_cost(Fuel fuel)
        {
            if (type == "gasfired")
            {
                pmax_cost = fuel.gas * efficiency / pmax;
            }
            if (type == "turbojet")
            {
                pmax_cost = fuel.kerosine * efficiency / pmax;
            }
            if (type == "windturbine")
            {
                pmax_cost = 0;
            }
        }

        public enum PowerPlanType
        {
            gasfired,
            turbojet,
            windturbine,
            co2
        }

    }
}
