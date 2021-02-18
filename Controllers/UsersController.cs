using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UsersContext _context = new UsersContext();

        public UsersController()
        {
            
        }

        [HttpGet]
        public IEnumerable<User> GetAll() => _context.Users;

        [HttpPost("validate/")]
        public bool Validate([FromBody] LoginData data)
        {
            return _context.Users.Where(x => x.EmailAdress == data.Login && x.Password == data.Password).FirstOrDefault() != null;
        }

        [HttpPost]
        public bool AddUser([FromBody] User toAdd)
        {
            var user = _context.Users.Where(x => x.EmailAdress == toAdd.EmailAdress).FirstOrDefault();

            if(user != null)
            {
                return false;
            }

            _context.Users.Add(toAdd);
            _context.SaveChanges();
            return true;

        }

        [HttpDelete("{id}")]
        public void DeleteUser(int id)
        {
            _context.Users.Remove(_context.Users.Where(x => x.Id == id).FirstOrDefault());
            _context.SaveChanges();
        }

        [HttpGet("{username}")]
        public User GetUserViaEmail(string username)
        {
            return _context.Users.Where(x => x.EmailAdress == username).FirstOrDefault();
        }
    }
}
