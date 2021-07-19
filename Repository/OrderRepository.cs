using Microsoft.EntityFrameworkCore;
using Net5Microservice.DbContexts;
using Net5Microservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net5Microservice.Repository;

namespace Net5Microservice.Repository
{
    public class OrderRepository : IOrdersRepository
    {
        private IApplicationDbContext _dbcontext;
        OrderRepository(IApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<string> Add(Order order)
        {
            _dbcontext.Orders.Add(order);
            await _dbcontext.SaveChanges();
            return order.Id.ToString();
        }

        public async Task<string> Cancel(int id)
        {
            var orderupt = await _dbcontext.Orders.Where(orderdet => orderdet.Id == id).FirstOrDefaultAsync();
            if (orderupt == null) return "Order does not exists";
            orderupt.Status = "Cancelled";
            await _dbcontext.SaveChanges();
            return "Order Cancelled Successfully";
        }

        public async Task<Order> GetByCustomerId(int custid)
        {
            var order = await _dbcontext.Orders.Where(orderdet => orderdet.CustomerId == custid).FirstOrDefaultAsync();
            return order;
        }
        public async Task<Order> GetById(int id)
        {
            var order = await _dbcontext.Orders.Where(orderdet => orderdet.Id == id).FirstOrDefaultAsync();
            return order;
        }

    }
}
