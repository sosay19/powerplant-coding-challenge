using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Text.Json;

namespace Engie_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionPlanController : ControllerBase
    {
        private readonly ILogger<ProductionPlanController> _logger;

        public ProductionPlanController(ILogger<ProductionPlanController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Payload payload)
        {
            try
            {
                var productionPlan = GenerateProductionPlan(payload);
                return Ok(productionPlan);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during production plan generation.");
                throw;
            }
        }

        private List<ResponseLoad> GenerateProductionPlan(Payload payload)
        {
            Fuel fuels = payload.fuels;
            double load = payload.load;
            List<Powerplant> powerplants = payload.powerplants;
            foreach (Powerplant powerplant in powerplants)
            {
                powerplant.set_pmax_cost(fuels);
            }
            List<Powerplant> powerplants_sorted_by_pmax_cost = powerplants.OrderBy(x => x.pmax_cost).ToList();
            foreach (Powerplant powerplant in powerplants_sorted_by_pmax_cost)
            {

                if (load >= powerplant.pmax)
                {
                    powerplant.current_load = powerplant.pmax;
                    load -= powerplant.pmax;
                }
                else
                {
                    powerplant.current_load = load;
                    load = 0;
                }
            }
            List<ResponseLoad> responseLoad = new List<ResponseLoad>();
            foreach (Powerplant powerplant in powerplants_sorted_by_pmax_cost)
            {
                responseLoad.Add(new ResponseLoad()
                {
                    name = powerplant.name,
                    p = powerplant.current_load,
                });

            }
            return responseLoad;
        }
    }
}
