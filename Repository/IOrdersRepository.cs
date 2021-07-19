using Net5Microservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5Microservice.Repository
{
    interface IOrdersRepository
    {
        Task<string> Add(Order order);
        Task<Order> GetById(int id);

        Task<string> Cancel(int id);

        Task<Order> GetByCustomerId(int custid);
    }
}
