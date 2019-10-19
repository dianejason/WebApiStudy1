using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web.Http;
using Models;

namespace WebApiStudy.Controllers
{
    public class UserController : ApiController
    {
        static ICollection<User> users;
        static UserController()
        {
            users = new Collection<User>();
            users.Add(new Models.User()
            {
                Id = "01",
                Name = "张三",
                LogInId = "zhangsan",
                Address = "长安街145号"
            });

            users.Add(new Models.User()
            {
                Id = "02",
                Name = "李四",
                LogInId = "lisi",
                Address = "珠江东路200号"
            });
            users.Add(new Models.User()
            {
                Id = "03",
                Name = "王五",
                LogInId = "wangwu",
                Address = "长安街145号"
            });
        }
        public IEnumerable<User> Get(string id = null)
        {
            return from contact in users
                   where contact.Id == id
 || string.IsNullOrEmpty(id)
                   select contact;
        }

        public void Post(User user)
        {
            user.Id = Guid.NewGuid().ToString();
            users.Add(user);
        }

        public void Put(User user)
        {
            users.Remove(users.First(n => n.Id == user.Id));
            users.Add(user);
        }

        public void Delete(string id)
        {
            users.Remove(users.First(n => n.Id == id));
        }

    }
}
