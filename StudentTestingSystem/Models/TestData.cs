using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTestingSystem.Models
{
    internal class TestData
    {
        private readonly TestContext context;
        private ObservableCollection<User> users;
        private ObservableCollection<Role> roles;
        public ObservableCollection<User> Users
        {
            get => users;
            set
            {
                users = value;
            }
        }
        public ObservableCollection<Role> Roles
        {
            get => roles;
            set
            {
                roles = value;
            }
        }
        public static void DataTest(TestContext context)
        {
            context = new();
            var r1 = new Role { IdRole = 1, RoleName = "admin" };
            context.Roles.Add(r1);
            var r2 = new Role { IdRole = 2, RoleName = "teacher" };
            context.Roles.Add(r2);
            var r3 = new Role { IdRole = 2, RoleName = "student" };
            context.Roles.Add(r3);
            var u1 = new User { UserName = "admin", UserSurname = "admin", UserLogin = "admin", UserPassword = "admin", RoleId = 1 };
            context.Users.Add(u1);
            var u2 = new User { UserName = "teacher", UserSurname = "teacher", UserLogin = "teacher", UserPassword = "teacher", RoleId = 2 };
            context.Users.Add(u2);
            var u3 = new User { UserName = "student", UserSurname = "student", UserLogin = "student", UserPassword = "student", RoleId = 3 };
            context.Users.Add(u3);
            context.SaveChanges();
        }
    }
}
