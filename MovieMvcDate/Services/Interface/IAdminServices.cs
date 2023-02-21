using MovieMvcDate.Models.Dto.RequestModel;
using MovieMvcDate.Models.Dto.ResponceModel;
using MovieMvcDate.Models.Entites;

namespace MovieMvcDate.Services.Interface
{
    public interface IAdminServices
    {
        Admin CreateAdmin(CretaAdminRequestModel admin);
        CretaAdminRequestModel  UpdateAdmin(CretaAdminRequestModel admin);

        public CretaAdminRequestModel GetAdminById(int id);
        //AdminDeleteRequestModel DeleteAdminById (AdminDeleteRequestModel adminId);
        void DeleteAdmin(int id);
        // LoginAdminRequestmodel LoginAdmin (LoginAdminRequestmodel Admin);
        Admin Login(string email, string password);
        IList<Admin> GetAllAdmin();
        public AdminResponceModel GetAdminByEmail(string email);


    }
}