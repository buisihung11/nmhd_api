﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMHD_DataAccess.Models
{
    public class OrderDetail
    {
        public OrderDetail(int orderId, int productId, int quantity, String productName)
        {
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
            ProductName = productName;
        }

        public Order Order { get; set; }
        public Product Product { get; set; }
        [Key,Column(Order = 1)]
        public int OrderId { get; set; }
        [Key, Column(Order = 2)]
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public String ProductName { get; set; }


    }
}
