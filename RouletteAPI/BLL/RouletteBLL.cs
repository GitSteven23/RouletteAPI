using BLL.Models.Roulette;
using DAL.Context;
using DAL.Entities;
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

        public CreationRouletteModel CreateRoulette(CreationRouletteModel createRouletteModel)
        {
            try
            {
                Roulettes roulette = new Roulettes()
                {
                    Name = createRouletteModel.Name,
                    State = true,
                    Opening_Date = null,
                    Closing_Date = null
                };
                Roulettes responseRoulette = rouletteRepository.CreateRoulette(roulette);
                rouletteRepository.Save();
                CreationRouletteModel responseCreateRoulette = new CreationRouletteModel()
                {
                    Roulette_ID = responseRoulette.Roulette_ID,
                    Name =  responseRoulette.Name
                };

                return responseCreateRoulette;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string OpeningRoulette(int roulette_Id)
        {
            try
            {
                Roulettes rouletteExist = rouletteRepository.GetRoulette(roulette_Id);

                rouletteExist.State = true;
                rouletteExist.Opening_Date = DateTime.UtcNow.ToLocalTime();

                bool updateRoulette = rouletteRepository.OpeningRoulette(rouletteExist);
                rouletteRepository.Save();
                if (updateRoulette)
                {
                    return "¡Operación exitosa!";
                }
                else 
                {
                    return "¡Operación denegada!";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
