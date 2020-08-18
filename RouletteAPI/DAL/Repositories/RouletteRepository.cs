using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Roulettes GetRoulette(int roulette_Id)
        {
            try
            {
                return context.Roulettes.Find(roulette_Id);
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
