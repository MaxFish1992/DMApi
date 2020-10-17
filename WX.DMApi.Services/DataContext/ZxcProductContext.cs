using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WX.DMApi.Model;

namespace WX.DMApi.Services.DataContext
{
    public class ZxcProductContext : DbContext
    {
        public ZxcProductContext(DbContextOptions<ZxcProductContext> options) : base(options)
        {

        }

        public DbSet<ZxcProductInfo> Products { get; set; }
    }
}
