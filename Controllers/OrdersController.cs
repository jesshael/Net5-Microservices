using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Net5Microservice.Models;
using Net5Microservice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        public class OrderController : ControllerBase
        {
            private IOrdersRepository _orderRepository;

            //public OrderController(IOrdersRepository orderRepository)
            //{
            //    _orderRepository = orderRepository;
            //}

            [HttpPost]
            [Route("Add")]
            public async Task<ActionResult> Add([FromBody] Order orderdet)
            {
                string orderid = await _orderRepository.Add(orderdet);
                return Ok(orderid);
            }
            [HttpGet]
            [Route("GetByCustomerId/{id}")]
            public async Task<ActionResult> GetByCustomerId(int id)
            {
                var orders = await _orderRepository.GetByCustomerId(id);
                return Ok(orders);
            }
            [HttpGet]
            [Route("GetById/{id}")]
            public async Task<ActionResult> GetById(int id)
            {
                var orderdet = await _orderRepository.GetById(id);
                return Ok(orderdet);
            }
            [HttpDelete]
            [Route("Cancel/{id}")]
            public async Task<IActionResult> Cancel(int id)
            {
                string resp = await _orderRepository.Cancel(id);
                return Ok(resp);
            }
        }
    }
}
