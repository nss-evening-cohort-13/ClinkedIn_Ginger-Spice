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
            new User { 
                Id = 1, 
                Email = "abc@gmail.com", 
                Password = "abc", 
                FirstName = "Alpha", 
                LastName = "Bet", 
                Gender = Gender.Nonbinary, 
                Age = 26, 
                Interests = new List<Interests>
                { 
                    Interests.Poetry,
                    Interests.Painting
                },
                Services = new List<Services>
                {
                    Services.Cooking,
                    Services.Reading
                }
            },
            new User { 
                Id = 2, 
                Email = "def@gmail.com", 
                Password = "def", 
                FirstName = "Beta", 
                LastName = "Fish", 
                Gender = Gender.Nonbinary, 
                Age = 26,
                Interests = new List<Interests>
                {
                    Interests.Coding,
                    Interests.Cooking
                }
            },
            new User { 
                Id = 3, 
                Email = "ghi@gmail.com", 
                Password = "ghi", 
                FirstName = "Charlie", 
                LastName = "Horse", 
                Gender = Gender.Nonbinary, 
                Age = 26,
                Interests = new List<Interests>
                {
                    Interests.Poetry,
                    Interests.Cooking
                }
            },
            new User { 
                Id = 4, 
                Email = "jkl@gmail.com", 
                Password = "jkl", 
                FirstName = "Delta", 
                LastName = "Airlines", 
                Gender = Gender.Nonbinary, 
                Age = 26,
                Interests = new List<Interests>
                {
                    Interests.Painting,
                    Interests.Coding
                }
            }
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


        public User GetUser(int id)
        {
            var user = _users.FirstOrDefault(user => user.Id == id);
            return user;

        }

        public void AddFriend(int userId, int friendId)
        {
            var userClinker = GetUser(userId);
            var friendClinker = GetUser(friendId);
            userClinker.Friends.Add(friendClinker);
        }
    }
}
