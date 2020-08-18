using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRouletteRepository : IDisposable
    {
        Roulettes GetRoulette(int roulette_Id);
        Roulettes CreateRoulette(Roulettes roulette);
        bool OpeningRoulette(Roulettes roulette);
        Bets CreateBet(Bets bet);
        Users GetUser(Guid user_Id);
        void Save();
    }
}
