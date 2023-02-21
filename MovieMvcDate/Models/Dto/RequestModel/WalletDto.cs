using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieMvcDate.Models.Dto.ResponceModel;

namespace MovieMvcDate.Models.Dto.RequestModel
{
    public class WalletDto
    {
        public int Id { get; set; }
        // public int UserId { get; set; }
        public double balance { get; set; }
        public string CustomerId { get; set; }
    }
    public class CreateWalletRequestModel
    {
        public int Id { get; set; }
        // public int UserId { get; set; }
        public double balance { get; set; }
        public int CustomerId { get; set; }
    
    }
    public class CreditWalletRequestModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public double balance { get; set; }
    }
    public class DebitWalletRequestModel
    {
        public double balance { get; set; }
        public string CustomerId { get; set; }
    }

     public class WalletResponceModel : BaseResponce
    {
        public WalletDto Data { get; set; }
    }


}