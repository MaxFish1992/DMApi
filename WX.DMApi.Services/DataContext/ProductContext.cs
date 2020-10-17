using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WX.DMApi.Model;

namespace WX.DMApi.Services.DataContext
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }

        public DbSet<ProductInfo> Products { get; set; }
    }
}
