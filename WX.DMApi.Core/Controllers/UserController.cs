using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WX.DMApi.IServices;
using WX.DMApi.Model;
using WX.DMApi.Util;

namespace WX.DMApi.Core.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService UserService;
        private readonly IConfiguration _configuration;
        private ILogger<UserController> _logger;
        public UserController(IUserService userService, IConfiguration configuration, ILogger<UserController> logger)
        {
            UserService = userService;
            _configuration = configuration;
            _logger = logger;
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

        //登录操作
        [HttpGet]
        [Route("login")]
        public string Login(string userName, string password)
        {
            UserMsg msg = new UserMsg()
            {
                Mark = 0,
                Msg = "",
                Token = "",
            };

            UserInfo user = UserService.GetUserByName(userName);
            //string password_form = _common.Get_MD5_Method1(model.password);

            if (user != null && user.Password == password)
            {
                JwtTokenUtil jwtTokenUtil = new JwtTokenUtil(_configuration);
                string token = jwtTokenUtil.GetToken(user);   //生成token
                //var headers = new HttpResponseMessage().Headers;
                //headers.Add("Authorization",token);

                msg.Mark = 1;
                msg.Msg = "登录成功";
                msg.Token = token;
                msg.Authority = user.Authority;
                _logger.LogInformation("用户" + user.UserName + "登录红象智能数字管理系统......");
            }
            else
            {
                msg.Msg = "用户名或者密码错误";
            }
            return JsonConvert.SerializeObject(msg);
        }
    }
}

