using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repositories
{
    public class RouletteRepository : IRouletteRepository, IDisposable
    {
        private RouletteContext context;
        private bool disposed = false;

        public RouletteRepository(RouletteContext context)
        {
            this.context = context;
        }
        public Roulettes GetRoulette(int rouletteId)
        {
            try
            {
                return context.Roulettes.Find(rouletteId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Roulettes CreateRoulette(Roulettes roulette)
        {
            try
            {
                return context.Roulettes.Add(roulette);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool OpeningRoulette(Roulettes roulette)
        {
            try
            {
                context.Entry(roulette).State = EntityState.Modified;

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }
        public Bets CreateBet(Bets bet)
        {
            try
            {
                return context.Bets.Add(bet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool ClosingRoulette(Roulettes roulette)
        {
            try
            {
                context.Entry(roulette).State = EntityState.Modified;

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }
        public List<Bets> GetBetsByRouletteId(Roulettes roulette)
        {
            try
            {
                List<Bets> bets = context.Bets.Where(b => b.Roulette_ID == roulette.Roulette_ID
                                                       && (b.Creation_Date >= roulette.Opening_Date && b.Creation_Date <= roulette.Closing_Date)
                                                       ).ToList();
                return bets;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Roulettes> GetRoulettes()
        {
            try
            {
                return context.Roulettes.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Users GetUser(Guid user_Id)
        {
            try
            {
                return context.Users.Find(user_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
