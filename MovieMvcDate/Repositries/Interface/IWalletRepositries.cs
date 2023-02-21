using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieMvcDate.Models.Dto.RequestModel;
using MovieMvcDate.Models.Entites;

namespace MovieMvcDate.Repositries.Interface
{
    public interface IWalletRepositries
    {

        Wallet Credit(Wallet wallet); 
        public double GetBalance(int CustomerId);
        public Wallet Willdraw(Wallet wallet);
       public Wallet GetWalletId(int CustomerId ,double balance);
    //    public Wallet FundWallet(int CustomerId, double wallet );
       public double UpdateWallet(Wallet balance);
       
    }
}