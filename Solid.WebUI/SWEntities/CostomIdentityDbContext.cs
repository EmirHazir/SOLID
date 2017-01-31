using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Solid.WebUI.SWEntities
{
    public class CostomIdentityDbContext:IdentityDbContext<CustomIdentityUser,CustomIdentityRole,string>
    {
        public CostomIdentityDbContext(DbContextOptions<CostomIdentityDbContext> options):base(options)
        {

        }
    }
}
