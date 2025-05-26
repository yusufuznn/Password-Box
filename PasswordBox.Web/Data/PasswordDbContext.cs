using Microsoft.EntityFrameworkCore;
using PasswordBox.Web.Models.Data;

namespace PasswordBox.Web.Data
{
    public class PasswordDbContext : DbContext
    {
        public PasswordDbContext(DbContextOptions<PasswordDbContext> options) : base(options)
        {
        }


        public DbSet<DataRecord> Records { get; set; }
    }

}
