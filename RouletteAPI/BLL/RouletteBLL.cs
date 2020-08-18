using BLL.Models.Bet;
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

        public RouletteModel CreateRoulette(CreationRouletteModel createRoulette)
        {
            try
            {
                Roulettes roulette = new Roulettes()
                {
                    Name = createRoulette.Name,
                    State = true,
                    Opening_Date = null,
                    Closing_Date = null
                };
                Roulettes responseRoulette = rouletteRepository.CreateRoulette(roulette);
                rouletteRepository.Save();
                RouletteModel responseCreateRoulette = new RouletteModel()
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
        public BetModel CreateBet(CreateBetModel createBet)
        {
            try
            {
                Users user = rouletteRepository.GetUser(createBet.User_ID);
                if (user != null)
                {
                    Bets bet = new Bets()
                    {
                        Roulette_ID = createBet.Roulette_ID,
                        User_ID = createBet.User_ID,
                        Number = createBet.Number,
                        Color = createBet.Color,
                        Money = createBet.Money,
                        State = true,
                        Creation_Date = DateTime.UtcNow.ToLocalTime(),
                        Creation_User = user.Name
                    };
                    Bets betResponse = rouletteRepository.CreateBet(bet);
                    rouletteRepository.Save();
                    BetModel betModelResponse = new BetModel()
                    {
                        Bet_ID = betResponse.Bet_ID,
                        User_ID = betResponse.User_ID,
                        Roulette_ID = betResponse.Roulette_ID,
                        Number = betResponse.Number == 0 ? 0 : betResponse.Number,
                        Color = betResponse.Color == "" ? "No aplica" : betResponse.Color,
                        Money = betResponse.Money,
                        State = betResponse.State == true ? "Activa" : "Vencida",
                        Creation_Date = betResponse.Creation_Date
                    };

                    return betModelResponse;
                }
                else 
                {
                    BetModel modelEmpty = new BetModel();
                    return modelEmpty;
                }               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
