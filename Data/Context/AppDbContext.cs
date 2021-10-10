using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yol.Data.Models;

namespace YolData.Context
{
    public class AppDbContext : IdentityDbContext<ApiUser, Role, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }
    }
}
