﻿using System;
using System.Collections.Generic;

namespace Programando.CSharp.WebApplication2.Model;

public partial class Summary_of_Sales_by_Year
{
    public DateTime? ShippedDate { get; set; }

    public int OrderID { get; set; }

    public decimal? Subtotal { get; set; }
}
