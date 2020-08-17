using DAL.Context;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RouletteBLL
    {
        private IRouletteRepository rouletteRepository;

        public RouletteBLL()
        {
            this.rouletteRepository = new RouletteRepository(new RouletteContext());
        }      
        public RouletteBLL(IRouletteRepository rouletteRepository)
        {
            this.rouletteRepository = rouletteRepository;
        }

        
    }
}
