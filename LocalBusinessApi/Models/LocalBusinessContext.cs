using Microsoft.EntityFrameworkCore;

namespace LocalBusinessApi.Models
{
  public class  LocalBusinessContext : DbContext
  {
    public LocalBusinessContext(DbContextOptions<LocalBusinessContext> options) :
    base(options)
    {

    }
    public DbSet<LocalBusiness> LocalBusinesses { get; set;}
  }
}