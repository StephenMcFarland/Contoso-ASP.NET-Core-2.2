using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Contoso.Models
{
    public class ContosoContext : DbContext
    {
        public ContosoContext (DbContextOptions<ContosoContext> options)
            : base(options)
        {
        }

        public DbSet<Contoso.Models.Student> Student { get; set; }
    }
}
