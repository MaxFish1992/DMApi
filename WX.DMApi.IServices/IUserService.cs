using System;
using System.Collections.Generic;
using System.Text;
using WX.DMApi.Model;

namespace WX.DMApi.IServices
{
    public interface IUserService
    {
        bool AddUser(UserInfo user);
        IEnumerable<UserInfo> GetUsers();
        UserInfo GetUserByName(string userName);
        bool UpdateUser(UserInfo user);
        bool DeleteUser(UserInfo user);
    }
}
