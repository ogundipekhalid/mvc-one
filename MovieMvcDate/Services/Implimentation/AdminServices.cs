using MovieMvcDate.Models.Dto.RequestModel;
using MovieMvcDate.Models.Dto.ResponceModel;
using MovieMvcDate.Models.Entites;
using MovieMvcDate.Repositries.Interface;
using MovieMvcDate.Services.Interface;

namespace MovieMvcDate.Services.Implimentation
{
    public class AdminServices : IAdminServices
    {
        private readonly IAdminRepositries _repo;
        private readonly IUserRepositries _userRepo;
         public AdminServices(IAdminRepositries repo, IUserRepositries userRepo)
        {
            _repo = repo;
            _userRepo = userRepo;
        }

        public Admin CreateAdmin(CretaAdminRequestModel admin)
        {
            // var sid = User.Generate
            var users = new User
            {
                Password = admin.Password,
                Email = admin.Email,
                IsActive = true,
                Role = "Admin"
            };
            var use = _userRepo.CreateUser(users);
            // var rand = new Random();
            admin.UserId = use.Id;
            admin.IsActive = true;
           

            var admin1 = new Admin
            {
                Id = admin.Id,
                FirstName = admin.FirstName,
                LastName = admin.LastName,
                Email = admin.Email,
                Password = admin.Password,
                PhoneNumber = admin.PhoneNumber,
                IsActive = true,
                UserId = use.Id
            };
            return _repo.CreateAdmin(admin1);
        }

        public void DeleteAdmin(int id)
        {
            var adm = _repo.GetAdminById(id);
            _repo.DeleteAdmin(adm);
        }

        public AdminResponceModel GetAdminByEmail(string email)
        {
             var admgmail = _repo.GetAdminByEmail(email);
            if (admgmail == null)
            {
                return null;
            }
            var AdminResponceModel = new AdminResponceModel
            {
                Message = "Admin retrieved Successfully",
                Status = true,
                Data = new AdminDto
                {
                    FirstName = admgmail.FirstName,
                    LastName = admgmail.LastName,
                    PhoneNumber = admgmail.PhoneNumber,
                    Email = admgmail.Email,
                    Id = admgmail.Id,
                    Password = admgmail.Password, 
                }
            };
            return AdminResponceModel;

        }

        public  CretaAdminRequestModel GetAdminById(int id )
        {
            var addm = _repo.GetAdminById(id);
            return new CretaAdminRequestModel
            {
                Id = addm.Id,
                FirstName = addm.FirstName,
                LastName = addm.LastName,
                Email = addm.Email,
                PhoneNumber = addm.PhoneNumber,
                Password = addm.PhoneNumber,
                IsActive = addm.IsActive,
            };
        }
        public IList<Admin> GetAllAdmin()
        {
            return _repo.GetAllAdmin();
        }

        public Admin Login(string email, string password)
        {
             return _repo.Login(email,password);
        }
        
        public CretaAdminRequestModel  UpdateAdmin(CretaAdminRequestModel admin)
        {
            var admins = _repo.GetAdminById(admin.Id);
            if (admins == null)
            {
                // throw new DirectoryNotFoundException();
                return null;
            }
            admins.FirstName = admin.FirstName ?? admins.FirstName;
            admins.LastName = admin.LastName ?? admins.LastName;
            admins.Email = admin.Email ?? admins.Email;
            admins.Password = admin.Password ?? admins.Password;
            admins.PhoneNumber = admin.PhoneNumber ?? admins.PhoneNumber;
            _repo.UpdateAdmin(admins);

            return admin;
                        
        }

    }
}