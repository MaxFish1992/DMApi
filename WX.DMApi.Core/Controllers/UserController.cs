using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WX.DMApi.IServices;
using WX.DMApi.Model;

namespace WX.DMApi.Core.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService UserService;

        public UserController(IUserService userService)
        {
            UserService = userService;
        }
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="authority"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("adduser")]
        public ActionResult<string> AddUser(string userName, string password, int authority = 3)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return "用户名不能为空";
            }

            if (string.IsNullOrEmpty(password))
            {
                return "密码不能为空";
            }

            var oldUser = UserService.GetUserByName(userName);
            if (oldUser != null)
            {
                return "该用户已存在";
            }

            var result = UserService.AddUser(new UserInfo() { UserName = userName, Password = password, Authority = authority });

            if (result)
            {
                return "注册成功";
            }
            else
            {
                return "注册失败，请重试";
            }
        }
        /// <summary>
        /// 获取用户密码
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getuser")]
        public ActionResult<string> GetUser(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return "用户名不能为空";
            }

            var result = UserService.GetUserByName(userName);
            
            return JsonConvert.SerializeObject(result);
        }

        [HttpGet]
        [Route("getusers")]
        public JsonResult GetUsers()
        {
            var users = UserService.GetUsers().ToList();
            return new JsonResult(users);
        }
    }
}
