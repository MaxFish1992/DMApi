using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WX.DMApi.Model;

namespace WX.DMApi.Services.DataContext
{
    public class MenuContext : DbContext
    {
        public MenuContext(DbContextOptions<MenuContext> options) : base(options)
        {

        }

        public DbSet<MenuInfo> Menus { get; set; }
    }
}
