using Gishe.presentation.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Gishe.Presentation.Infrastructure.Persistence.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    public DbSet<Consumer> Consumers { get; set; }
}