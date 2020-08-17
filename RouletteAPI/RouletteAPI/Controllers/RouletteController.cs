using BLL;
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

        public RouletteController(RouletteBLL rouletteBLL)
        {
            this.rouletteBLL = rouletteBLL;
        }

    }
}
