using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn_Ginger_Spice.Models;

namespace ClinkedIn_Ginger_Spice.DataAccess
{
    public class UserRepository
    {
        static List<User> _users = new List<User>
        {
            new User { Id = 1, Email = "abc@gmail.com", Password = "abc", FirstName = "Alpha", LastName = "Bet", Gender = Gender.Nonbinary, Age = 26 },
            new User { Id = 2, Email = "def@gmail.com", Password = "def", FirstName = "Beta", LastName = "Fish", Gender = Gender.Nonbinary, Age = 26 },
            new User { Id = 3, Email = "ghi@gmail.com", Password = "ghi", FirstName = "Charlie", LastName = "Horse", Gender = Gender.Nonbinary, Age = 26 },
            new User { Id = 4, Email = "jkl@gmail.com", Password = "jkl", FirstName = "Delta", LastName = "Airlines", Gender = Gender.Nonbinary, Age = 26 }
        };

        public List<User> GetAll()
        {
            return _users;
        }

        public void Add(User user)
        {
            var biggestExistingId = _users.Max(person => person.Id);
            user.Id = biggestExistingId + 1;

            _users.Add(user);
        }
    }
}
