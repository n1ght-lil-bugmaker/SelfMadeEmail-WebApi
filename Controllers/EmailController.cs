using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Model;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {

        private EmailContext _context = new EmailContext();

        public EmailController()
        {

        }

        [HttpGet]
        public IEnumerable<Email> Get()
        {
            return _context.Emails;
        }

        

        [HttpPost]
        public void AddEmail([FromBody] Email toAdd)
        {
            _context.Emails.Add(toAdd);
            _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _context.Emails.Remove(
                _context.Emails.Where(x => x.Id == id).FirstOrDefault()
                );

            _context.SaveChanges();
        }

        [HttpGet("received/{username}")]
        public IEnumerable<Email> GetEmailsForCurrentUser(string username)
        {
            return _context.Emails.Where(x => x.Target == username);
        }

        [HttpGet("sended/{username}")]
        public IEnumerable<Email> GetEmailsSendedByCurrentUser(string username)
        {
            return _context.Emails.Where(x => x.Source == username);
        }
    }
}