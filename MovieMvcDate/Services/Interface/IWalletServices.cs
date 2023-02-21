using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieMvcDate.Models.Dto.RequestModel;
using MovieMvcDate.Models.Entites;

namespace MovieMvcDate.Services.Interface
{
    public interface IWalletServices
    {
      
        CreditWalletRequestModel Credit (CreditWalletRequestModel walletRequestModel);
        double GetBalance(int CustomerId );
        DebitWalletRequestModel Willdraw (DebitWalletRequestModel wallet);
        double UpdateWallet (Wallet  wallet);
       // public WalletResponceModel FundWallet(int CustomerId, double balance );
        Wallet GetWalletId(int CustomerId , double balance);

    }
}