using System;
using System.Collections.Generic;

namespace DATABASE_FIRST.Models;

public partial class Sinhvien
{
    public string Masv { get; set; } = null!;

    public string? Hoten { get; set; }

    public string? Makhoa { get; set; }

    public string? Malop { get; set; }

    public DateOnly? Dob { get; set; }

    public virtual Khoa? MakhoaNavigation { get; set; }

    public virtual Lop? MalopNavigation { get; set; }
}
