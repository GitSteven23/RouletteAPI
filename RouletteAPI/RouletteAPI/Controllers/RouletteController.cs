using BLL;
using BLL.Models.Bet;
using BLL.Models.Roulette;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace RouletteAPI.Controllers
{
    public class RouletteController : ApiController
    {
        private RouletteBLL rouletteBLL;

        public RouletteController()
        {
            this.rouletteBLL = new RouletteBLL();
        }
        public RouletteController(RouletteBLL rouletteBLL)
        {
            this.rouletteBLL = rouletteBLL;
        }

        [HttpPost]
        [Route("api/CreateRoulette")]
        public IHttpActionResult CreateRoulette([FromBody] CreationRouletteModel createRoulette)
        {
            try
            {
                RouletteModel rouletteModel = rouletteBLL.CreateRoulette(createRoulette);
                if (rouletteModel == null)
                {
                    return NotFound();
                }

                return Ok(rouletteModel.Roulette_ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut]
        [Route("api/OpeningRoulette")]
        public IHttpActionResult OpeningRoulette(int rouletteId)
        {
            try
            {
                string openingRoulette = rouletteBLL.OpeningRoulette(rouletteId);
                if (String.IsNullOrEmpty(openingRoulette))
                {
                    return NotFound();
                }

                return Ok(openingRoulette);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("api/CreateBet")]
        public IHttpActionResult CreateBet([FromBody] CreateBetModel createBet)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    BetModel betModel = rouletteBLL.CreateBet(createBet);
                    if (betModel == null)
                    {
                        return NotFound();
                    }

                    return Ok(betModel);
                }

                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut]
        [Route("api/ClosingRoulette")]
        public IHttpActionResult ClosingRoulette(int rouletteId)
        {
            try
            {
                List<BetModel> betsRoulette = rouletteBLL.ClosingRoulette(rouletteId);
                if (betsRoulette == null)
                {
                    return NotFound();
                }

                return Ok(betsRoulette);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        public IHttpActionResult GetRoulettes()
        {
            try
            {
                List<RouletteModel> roulettes = rouletteBLL.GetRoulettes();
                if (roulettes == null)
                {
                    return NotFound();
                }

                return Ok(roulettes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
