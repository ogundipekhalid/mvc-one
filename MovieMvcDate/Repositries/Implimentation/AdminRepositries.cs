using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieMvcDate.ApplicationDbContext;
using MovieMvcDate.Models.Entites;
using MovieMvcDate.Repositries.Interface;

namespace MovieMvcDate.Repositries.Implimentation
{
    public class AdminRepositries :IAdminRepositries
    {
        public readonly ApplictionContext _admincontext;

         public AdminRepositries(ApplictionContext admincontext)
        {
            _admincontext = admincontext;
        }
        public Admin CreateAdmin(Admin admin)
        {
          _admincontext.Admins.Add(admin);
          _admincontext.SaveChanges();
          return admin;
        }
        public Admin DeleteAdmin(Admin admin)
        {
            _admincontext.Admins.Remove(admin);
            _admincontext.SaveChanges();
            return admin;
        }

        public Admin GetAdminByEmail(string email)
        {
             var admini = _admincontext.Admins.SingleOrDefault(x => x.Email == email);
            return admini;
        }

        public Admin GetAdminById(int id)
        {
           return _admincontext.Admins.SingleOrDefault(a => a.Id == id);
        }
        public IList<Admin> GetAllAdmin()
        {
            return _admincontext.Admins.ToList();
        }

        public Admin Login(string email, string password)
        {
          return _admincontext.Admins.SingleOrDefault(a => a.Email == email && a.Password ==password);
        //    return _admincontext.Admins.FirstOrDefault(a => a.Email == email && a.Password == passWord);
        }
        public Admin UpdateAdmin(Admin admin)

        {
            _admincontext.Admins.Update(admin);
            _admincontext.SaveChanges();
            return admin;
        }

        

    }
}