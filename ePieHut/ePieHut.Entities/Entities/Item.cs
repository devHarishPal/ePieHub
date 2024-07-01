﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ePieHut.Entities.Entities;

public partial class Item
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal UnitPrice { get; set; }

    public string ImageUrl { get; set; }

    public int CategoryId { get; set; }

    public int ItemTypeId { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public virtual Category Category { get; set; }

    public virtual ItemType ItemType { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}