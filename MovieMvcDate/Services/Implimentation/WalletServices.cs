using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieMvcDate.Models.Dto.RequestModel;
using MovieMvcDate.Models.Entites;
using MovieMvcDate.Repositries.Interface;
using MovieMvcDate.Services.Interface;

namespace MovieMvcDate.Services.Implimentation
{
    public class WalletServices : IWalletServices
    {
        private readonly IWalletRepositries _wallet;

        private readonly ICustomerRepositries _CustomerRepo;
        private readonly IUserRepositries _UserRepo;
        public WalletServices(IWalletRepositries wallet, ICustomerRepositries CustomerRepo, IUserRepositries UserRepo)
        {
            _wallet = wallet;
            _CustomerRepo = CustomerRepo;
            _UserRepo = UserRepo;
        }

        public CreditWalletRequestModel Credit(CreditWalletRequestModel walletRequestModel)
        {
            var wallet = _wallet.GetWalletId(walletRequestModel.CustomerId,walletRequestModel.balance);
            wallet.Balance += walletRequestModel.balance;
            _wallet.UpdateWallet(wallet);
            return walletRequestModel;
        }

        public double GetBalance(int CustomerId)
        {
            // var bil = 
            var balanc = _wallet.GetBalance(CustomerId);
            return CustomerId;
        }

        // public WalletResponceModel FundWallet(int CustomerId, double Wallet )
        // {
        //     var  fund = _wallet.GetWalletId(CustomerId);
        //     if (fund == null)
        //     return new WalletResponceModel
        //     {
        //         Message = "",
        //         Status = false,
        //     };
        //     fund.User.wallet += Wallet;
        //     _wallet.UpdateWallet(wallet);
        //     return new WalletResponceModel{
        //         Message = "sucess"
        //         Status = true,
        //     };
        // }

        public double UpdateWallet(Wallet wallet)
        {

            var update = _wallet.GetWalletId(wallet.CustomerId,wallet.Balance);
            if (update == null)
            {
                throw new NotImplementedException();
            }
            update.Balance = update.Balance < 0 ? update.Balance : update.Balance;
            return _wallet.UpdateWallet(wallet);
             
            //update.Balance = update.Balance < 0 ? update.Balance : update.Balance;
        }
        
        public DebitWalletRequestModel Willdraw(DebitWalletRequestModel wallet)
        {
            {
                var walle = new Wallet
                {
                    // CustomerId= wallet.CustomerId,
                    Balance = wallet.balance,
                };
                _wallet.Credit(walle);
                return wallet;
            }
        }

        public Wallet GetWalletId(int CustomerId , double balance)
        {
            var cutom = _wallet.GetWalletId(CustomerId,balance);
            if (cutom == null)
            {
                return null;
            }
            var GetWalletId = new Wallet
            {
                CustomerId = cutom.CustomerId,
                Balance =cutom.Balance,
            };
            return GetWalletId;

        }

        public double GetBalance(int CustomerId, double balance)
        {
            throw new NotImplementedException();
        }

        // public WalletResponceModel FundWallet(int CustomerId, double wallet)
        // {
        //     throw new NotImplementedException();
        // }
    }
}