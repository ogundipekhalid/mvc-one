using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieMvcDate.Models.Entites;

namespace MovieMvcDate.Repositries.Interface
{
    public interface IUserRepositries
    {
        User UpdateUser(User user);
        User DeleteUser(User user);
        User CreateUser(User user);
        User Login(string email, string Password);
        User GetUserById(int id);
        IList<User> GetAllUser();

    }
}