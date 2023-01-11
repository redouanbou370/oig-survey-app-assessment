using Microsoft.EntityFrameworkCore;
using QuestionnairesServer.Entities;

namespace QuestionnairesServer.Database;


public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);

        modelBuilder.Entity<Status>().HasData(new Status[]
        {
            new () { Id = 1, Name = "Concept" },
            new () { Id = 2, Name = "Scheduled" },
            new () { Id = 3, Name = "Active" },
            new () { Id = 4, Name = "Completed" }
        });

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Status> Status { get; set; }
    public DbSet<Questionnaire> Questionnaires { get; set; }
}