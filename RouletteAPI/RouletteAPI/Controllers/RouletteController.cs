using BLL;
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
        public IHttpActionResult CreateRoulette([FromBody] CreationRouletteModel rouletteCreate)
        {
            try
            {
                CreationRouletteModel rouletteModel = rouletteBLL.CreateRoulette(rouletteCreate);
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

    }
}
