using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WX.DMApi.IServices;
using WX.DMApi.Model;
using WX.DMApi.Services.DataContext;

namespace WX.DMApi.Services
{
    public class UserService : IUserService
    {
        public UserContext Context;

        public UserService(UserContext context)
        {
            Context = context;
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool AddUser(UserInfo user)
        {
            Context.User.Add(user);
            return Context.SaveChanges() > 0;
        }

        public IEnumerable<UserInfo> GetUsers()
        {
            return Context.User.ToList();
        }
        /// <summary>
        /// 根据用户名获取用户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public UserInfo GetUserByName(string userName)
        {
            return Context.User.SingleOrDefault(x => x.UserName.Equals(userName));
        }
        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool UpdateUser(UserInfo user)
        {
            var state = false;
            var oldUser = Context.User.SingleOrDefault(x => x.UserName.Equals(user.UserName));

            if (oldUser != null)
            {
                oldUser.Password = user.Password;
                state = Context.SaveChanges() > 0;
            }

            return state;
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool DeleteUser(UserInfo user)
        {
            var oldUser = Context.User.SingleOrDefault(x => x.UserName.Equals(user.UserName));
            if (oldUser != null)
                Context.User.Remove(user);
            return Context.SaveChanges() > 0;
        }
    }
}
