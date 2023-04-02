using System;
using System.Collections.Generic;

namespace Programando.CSharp.WebApplication2.Model;

public partial class Sales_by_Category
{
    public int CategoryID { get; set; }

    public string CategoryName { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public decimal? ProductSales { get; set; }
}
