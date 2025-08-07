using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingApp.Models
{
    public static class Repository
    {
        public static List<UserInfo> Users { get; set; } = new List<UserInfo>();

        static Repository()
        {
            Users = new List<UserInfo> { };

            Users.Add(new UserInfo
            {
                Id = 1,
                Name = "Ali",
                Phone = "1234567890",
                Email = "acb",
                WillAttend = true
            });
            Users.Add(new UserInfo
            {
                Id = 2,
                Name = "Ali",
                Phone = "1234567890",
                Email = "acb",
                WillAttend = true
            });
            Users.Add(new UserInfo
            {
                Id = 3,
                Name = "Ali",
                Phone = "1234567890",
                Email = "acb",
                WillAttend = true
            });
            Users.Add(new UserInfo
            {
                Name = "Ali",
                Phone = "1234567890",
                Email = "acb",
                WillAttend = true
            });
        }




        public static void AddUser(UserInfo user)
        {
            // Logic to add user to the repository
            // This could involve adding to a database or an in-memory list
            user.Id = Users.Count + 1; // Simple ID generation logic
            Users.Add(user);
        }
        

        public static UserInfo? GetUserById(int id)
        {
            // Logic to retrieve a user by ID
            return Users.FirstOrDefault(u => u.Id == id);
        }
    }
}