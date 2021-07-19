using Microsoft.EntityFrameworkCore;
using Net5Microservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5Microservice.DbContexts
{
    interface IApplicationDbContext
    {
        DbSet<Order> Orders{get; set; }
        Task<int> SaveChanges();
    }
}
