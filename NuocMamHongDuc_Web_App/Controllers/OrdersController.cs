using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NMHD_DataAccess.Constraints;
using NMHD_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NuocMamHongDuc_Web_App.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly NMHDDbContext _context;

        public OrdersController(NMHDDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        [HttpPost]
        public ActionResult<Order> CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        }

        [HttpPut("{id}")]
        public ActionResult<Order> UpdateOrder(int id, Order order)
        {
            if(id != order.Id)
            {
                return BadRequest();
            }
            _context.Orders.Update(order);
            _context.SaveChanges();
            return order;
        }
        [HttpPut("{id}/status")]
        public ActionResult<Order> UpdateOrderStatus(int id, int orderStatus)
        {
            var order = _context.Orders.FirstOrDefault((o) => o.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            order.Status = (OrderStatus) orderStatus;
            _context.SaveChanges();
            return order;
        }
    }
}
