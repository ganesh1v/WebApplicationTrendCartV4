﻿using System;
using System.Collections.Generic;

namespace WebApplicationTrendCartV4.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int UserId { get; set; }

    public DateTime? OrderDate { get; set; }

    public string? Status { get; set; } = null!;

    public decimal TotalAmount { get; set; }

    public decimal? Tax { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual User? User { get; set; } = null!;
}
