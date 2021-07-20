using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NMHD_DataAccess.Constraints;
using NMHD_DataAccess.Models;
using NMHD_DataAccess.ViewModels;
using System;
using System.Collections;
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
        public ActionResult<Order> CreateOrder(OrderCreaterRequestModel orderModel)
        {
            if (orderModel.Products.Count == 0)
            {
                return BadRequest();
            }

            var order = new Order(orderModel.CheckInDate, orderModel.CustName, orderModel.CustPhone, orderModel.CustEmail, orderModel.Note, (int)OrderStatus.New);
            _context.Orders.Add(order);
            _context.SaveChanges();
            IList<OrderDetail> orderDetails = new List<OrderDetail>();
            foreach (var prod in orderModel.Products)
            {
                orderDetails.Add(new OrderDetail(order.Id, prod.ProductId, prod.Quantity));
            }
            _context.OrderDetails.AddRange(orderDetails);

            _context.SaveChanges();
            return order;
        }

        [HttpPut("{id}")]
        public ActionResult<Order> UpdateOrder(int id, Order order)
        {
            if (id != order.Id)
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
            order.Status = (OrderStatus)orderStatus;
            _context.SaveChanges();
            return order;
        }
    }
}
