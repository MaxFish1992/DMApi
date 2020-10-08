using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WX.DMApi.Model;

namespace WX.DMApi.Services.DataContext
{
    public class ZxcOrderContext: DbContext
    {
        public ZxcOrderContext(DbContextOptions<ZxcOrderContext> options) : base(options)
        {

        }

        public DbSet<ZxcOrderInfo> Orders { get; set; }
    }
}
