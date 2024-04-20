using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CODE_FIRST.Models;

namespace CODE_FIRST.Data
{
    public class SinhviensContext : DbContext
    {
        public SinhviensContext (DbContextOptions<SinhviensContext> options)
            : base(options)
        {
        }

        public DbSet<CODE_FIRST.Models.SINHVIEN> SINHVIEN { get; set; } = default!;
    }
}
