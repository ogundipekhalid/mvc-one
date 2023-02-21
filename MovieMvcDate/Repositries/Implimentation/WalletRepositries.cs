using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieMvcDate.ApplicationDbContext;
using MovieMvcDate.Models.Entites;
using MovieMvcDate.Repositries.Interface;

namespace MovieMvcDate.Repositries.Implimentation
{
    public class WalletRepositries : IWalletRepositries
    {
         private readonly ApplictionContext _context;
       public WalletRepositries(ApplictionContext context)
        {
            context = context;
        }
        //addmoney to wallet 
        public Wallet Credit(Wallet wallet)
        {
            _context.wallets.Add(wallet);
            _context.SaveChanges();
            return wallet;
        }
        public Wallet Willdraw(Wallet wallet)
        {
             _context.wallets.Remove(wallet);
            _context.SaveChanges();
            return wallet; 
        }

        public double GetBalance(int CustomerId)
        {
            var balanc = _context.wallets.Sum(x => (x.Balance - x.Balance));
            return balanc; 
        }

        public Wallet GetWalletId(int CustomerId,double balance)
        {
            var Getid = _context.wallets.Include(x=>x.Customer).FirstOrDefault(c => c.CustomerId == CustomerId);
            return Getid;
        }
        // public Wallet FundWallet(int CustomerId, double wallet )
        // {
        //     var Getid = _context.wallets.Include(x=>x.User).FirstOrDefault(c => c.CustomerId == CustomerId);
        //     return Getid;
        // }
         public double UpdateWallet(Wallet balance)
        {
            var balances = _context.wallets.Sum(x => (x.Balance - x.Balance));
            return balances; 
        }


        
    }
}