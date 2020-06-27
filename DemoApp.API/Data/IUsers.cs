using System.Collections.Generic;
using System.Threading.Tasks;
using DemoApp.API.Models;

namespace DemoApp.API.Data
{
    public interface IUsers
    {
         Task<IEnumerable<User>> GetUsers();
         Task<User> GetUser(int id);
    }
}