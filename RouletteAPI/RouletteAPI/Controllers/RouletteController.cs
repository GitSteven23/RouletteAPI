using BLL;
using BLL.Models.Bet;
using BLL.Models.Roulette;
using DAL.Context;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
                BetModel betModel = rouletteBLL.CreateBet(createBet);
                if (betModel == null)
                {
                    return NotFound();
                }

                return Ok(betModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
