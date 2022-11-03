using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;

using VirtualLeague.Models.ConData;
using VirtualLeague.Models;

namespace VirtualLeague.Data
{
  public partial class ConDataContext : Microsoft.EntityFrameworkCore.DbContext
  {
        partial void OnModelBuilding(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers");
        }
  }
}
