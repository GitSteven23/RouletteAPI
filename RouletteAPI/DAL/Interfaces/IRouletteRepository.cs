using DAL.Entities;
using System;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IRouletteRepository : IDisposable
    {
        Roulettes GetRoulette(int roulette_Id);
        Roulettes CreateRoulette(Roulettes roulette);
        bool OpeningRoulette(Roulettes roulette);
        Bets CreateBet(Bets bet);
        bool ClosingRoulette(Roulettes roulette);
        List<Bets> GetBetsByRouletteId(Roulettes roulette);
        List<Roulettes> GetRoulettes();
        Users GetUser(Guid user_Id);
        void Save();
    }
}
