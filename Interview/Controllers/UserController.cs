using System.Linq;
using Interview.Models;
using Microsoft.AspNetCore.Mvc;

namespace Interview.Controllers
{
    public class UserController : ControllerBase
    {
        [HttpPost]
        public ActionResult AddUser(string name, string surname, string email, string age, string city, string postcode, string street)
        {
            bool result;
            var user = new User();
            var context = new ApplicationDbContext();
            
            if (name is null)
            {
                result = false;
            }
            if (surname is null)
            {
                result = false;
            }

            int ageValue = int.Parse(age);
            if (ageValue < 18)
            {
                user.Type = "Junior";
            }
            else
            {
                user.Type = "Senior";
            }
            
            if (city is null)
            {
                result = false;
            }
            if (string.IsNullOrEmpty(email))
            {
                result = false;
            }
            if (postcode is null)
            {
                result = false;
            }
            if (street is null)
            {
                result = false;
            }

            var users = context.Users.ToList();
            if (users.FirstOrDefault(u => u.Email == email) != null)
            {
                result = false;
            }
            
            user.Age = age;
            user.City = city;
            user.Name = name;
            user.Surname = surname;
            user.PostCode = postcode;
            user.Street = street;
            
            context.Users.Add(user);
            result = true;

            return Ok(result);
        }
    }
}