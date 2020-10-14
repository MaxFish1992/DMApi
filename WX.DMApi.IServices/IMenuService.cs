using System;
using System.Collections.Generic;
using System.Text;
using WX.DMApi.Model;

namespace WX.DMApi.IServices
{
    /// <summary>
    /// 导航栏服务接口
    /// </summary>
    public interface IMenuService
    {
        /// <summary>
        /// 根据权限获取菜单
        /// </summary>
        /// <returns></returns>
        IEnumerable<MenuInfo> GetMenuByAuthority(int authority);
    }
}
