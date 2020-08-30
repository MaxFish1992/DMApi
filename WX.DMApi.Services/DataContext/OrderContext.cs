using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WX.DMApi.Model;

namespace WX.DMApi.Services.DataContext
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {

        }

        public DbSet<OrderInfo> Orders { get; set; }
    }
}
