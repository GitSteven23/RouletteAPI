using BLL.Models.Bet;
using BLL.Models.Roulette;
using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

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
                    Name = responseRoulette.Name
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
                        Color = createBet.Color == "" ? "No aplica" : createBet.Color,
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
        public List<BetModel> ClosingRoulette(int roulette_Id)
        {
            try
            {
                Roulettes rouletteExist = rouletteRepository.GetRoulette(roulette_Id);
                rouletteExist.State = false;
                rouletteExist.Closing_Date = DateTime.UtcNow.ToLocalTime();

                bool updateRoulette = rouletteRepository.ClosingRoulette(rouletteExist);
                rouletteRepository.Save();

                Roulettes updatedRoulette = rouletteRepository.GetRoulette(roulette_Id);
                List<Bets> betsRoulette = rouletteRepository.GetBetsByRouletteId(updatedRoulette);

                List<BetModel> betResponse = betsRoulette.Select(
                    betModel => new BetModel
                    {
                        Bet_ID = betModel.Bet_ID,
                        User_ID = betModel.User_ID,
                        Roulette_ID = betModel.Roulette_ID,
                        Number = betModel.Number == 0 ? 0 : betModel.Number,
                        Color = betModel.Color == "" ? "No aplica" : betModel.Color,
                        Money = betModel.Money,
                        State = betModel.State == true ? "Activa" : "Vencida",
                        Creation_Date = betModel.Creation_Date
                    }).ToList();

                return betResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<RouletteModel> GetRoulettes()
        {
            try
            {
                List<Roulettes> roulettes = rouletteRepository.GetRoulettes();

                List<RouletteModel> roulettesResponse = roulettes.Select(
                    rouletteModel => new RouletteModel
                    {
                        Roulette_ID = rouletteModel.Roulette_ID,
                        Name = rouletteModel.Name,
                        State = rouletteModel.State == true ? "Abierta" : "Cerrada",
                        Opening_Date = rouletteModel.Opening_Date,
                        Closing_Date = rouletteModel.Closing_Date
                    }).ToList();

                return roulettesResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
