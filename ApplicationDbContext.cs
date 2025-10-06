using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Optional: apply configurations
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

    }

    public DbSet<Location> Locations { get; set; }
    public DbSet<Category> Categories { get; set; }

    public DbSet<Participant> Participants { get; set; }
    
    public DbSet<Show> Shows { get; set; }

    public DbSet<Review> Reviews { get; set; }

    public DbSet<Purchase> Purchases { get; set; }

    public DbSet<TicketType> TicketTypes { get; set; }

    public DbSet<Ticket> Tickets { get; set; }

    public DbSet<Incercare> Incercari => Set<Incercare>();

}