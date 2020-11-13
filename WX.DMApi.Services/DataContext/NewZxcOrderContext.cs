using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WX.DMApi.Model;

namespace WX.DMApi.Services.DataContext
{
    public class NewZxcOrderContext : DbContext
    {
        public NewZxcOrderContext(DbContextOptions<NewZxcOrderContext> options) : base(options)
        {

        }

        public DbSet<NewZxcOrderInfo> Orders { get; set; }
    }
}
