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
    public class MenuController : ControllerBase
    {
        public IMenuService MenuService;

        public MenuController(IMenuService orderService)
        {
            MenuService = orderService;
        }
        /// <summary>
        /// 获取菜单项
        /// </summary>
        /// <param name="authority"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getmenu")]
        public string GetMenuByAuthority(int authority)
        {
            return JsonConvert.SerializeObject(MenuService.GetMenuByAuthority(authority));
        }
    }
}
