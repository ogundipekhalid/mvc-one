using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieMvcDate.Models.Dto.RequestModel;
using MovieMvcDate.Services.Interface;

namespace MovieMvcDate.Controllers
{
    public class WalletController : Controller
    {
        private readonly IWalletServices _wallet;
        private readonly IUserServices _user;
        public WalletController(IWalletServices wallet)
        {
            _wallet = wallet;
        }
        public IActionResult IndexWallet()
        {
            return View();
        }

        public IActionResult Credit()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreditWallet(CreditWalletRequestModel walletRequestModel)
        {
            // if (walletRequestModel != null)
            // {
                _wallet.Credit(walletRequestModel);
                TempData["success"] = "Credited suceesfully ";
                return RedirectToAction("CustomerDashborad","Customer");
            // }
            // else
            // {
            //     ViewBag.Error = "wroung input";
            //     return View();
            // }
        }

        public IActionResult GetBalance()
        {
            return View();
        }

        public IActionResult GetBalances(int CustomerId)
        {
            var user = User.FindFirst(ClaimTypes.Email).Value;

            var Balance = _wallet.GetBalance(CustomerId);
            return View(Balance);
        }
        //   public IActionResult ()
        // {
        //     return View();
        // }

    }
}