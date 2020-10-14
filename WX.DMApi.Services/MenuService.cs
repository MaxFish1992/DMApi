using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WX.DMApi.IServices;
using WX.DMApi.Model;
using WX.DMApi.Services.DataContext;

namespace WX.DMApi.Services
{
    public class MenuService : IMenuService
    {
        public MenuContext Context;
        public MenuService(MenuContext context)
        {
            Context = context;
        }
        /// <summary>
        /// 根据权限获取菜单项
        /// </summary>
        /// <param name="authority"></param>
        /// <returns></returns>
        public IEnumerable<MenuInfo> GetMenuByAuthority(int authority)
        {
            return Context.Menus.ToList().FindAll(x=>x.Authority>= authority);
        }
    }
}
