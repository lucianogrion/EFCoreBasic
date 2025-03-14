using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EFTestingAPP.Models;

namespace EFTestingAPP.Data
{
    public class EFTestingAPPContext : DbContext
    {
        public EFTestingAPPContext (DbContextOptions<EFTestingAPPContext> options)
            : base(options)
        {
        }

        public DbSet<EFTestingAPP.Models.ClientModelcs> ClientModels { get; set; } = default!;
    }
}
