using System;
using System.Collections.Generic;

namespace MyStore_Data.Entities;

public partial class Slider
{
    public int SliderId { get; set; }

    public string? DiscountTitle { get; set; }

    public string Title { get; set; } = null!;

    public string? ImageName { get; set; }

    public DateTime Startdate { get; set; }

    public DateTime Enddate { get; set; }

    public bool IsActive { get; set; }
}
