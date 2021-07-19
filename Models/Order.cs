using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5Microservice.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public double Cost { get; set; }
        public DateTime Placed { get; set; }
        public int CustomerId { get; set; }
        public string Status { get; set; }
    }
}
