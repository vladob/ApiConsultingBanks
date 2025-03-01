using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

/// <summary>
/// Definition of DbContext
/// </summary>
public class MyDbContext : DbContext
{
    /// <summary>
    /// Basic constructor for DbContext
    /// </summary>
    /// <param name="options"></param>
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }

    // Define your DbSets (tables) here
    /// <summary>
    /// DEfinition of DbSet (table) USers
    /// </summary>
    public DbSet<User> Users { get; set; }

    // Define your DbSets (tables) here
    /// <summary>
    /// DEfinition of DbSet (table) USers
    /// </summary>
    public DbSet<Document> Documents { get; set; }

    /// <summary>
    /// Configure the Active field with type conversion
    /// Configure the ID field as identity and read-only after creation
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure the Active field with type conversion
        modelBuilder.Entity<User>()
            .Property(u => u.Active)
            .HasConversion(
                v => (byte)((bool)v ? 1 : 0),  // Converts bool to byte
                v => v == 1              // Converts byte to bool
            );

        // Configure the ID field as identity and read-only after creation
        modelBuilder.Entity<User>()
            .Property(u => u.Id)
            .ValueGeneratedOnAdd();

        // Configure the ID field as identity and read-only after creation
        modelBuilder.Entity<Document>()
            .Property(u => u.Id)
            .ValueGeneratedOnAdd();
    }

}
