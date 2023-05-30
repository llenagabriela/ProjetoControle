using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoControle.Models;

namespace ProjetoControle.Data
{
    public class ProjetoControleContext : DbContext
    {
        public ProjetoControleContext (DbContextOptions<ProjetoControleContext> options)
            : base(options)
        {
        }

        public DbSet<ProjetoControle.Models.ParkingControl> ParkingControl { get; set; } = default!;
    }
}
