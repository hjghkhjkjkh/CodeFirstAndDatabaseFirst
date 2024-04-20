using System;
using System.Collections.Generic;

namespace DATABASE_FIRST.Models;

public partial class Khoa
{
    public string Makhoa { get; set; } = null!;

    public string? Tenkhoa { get; set; }

    public virtual ICollection<Sinhvien> Sinhviens { get; set; } = new List<Sinhvien>();
}
