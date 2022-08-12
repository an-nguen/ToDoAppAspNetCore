using Microsoft.EntityFrameworkCore;
using ToDoApp.Domains;

namespace ToDoApp.Data;

public class ToDoDbContext: DbContext
{
    public DbSet<Board> Boards => Set<Board>();
    public DbSet<TaskCard> TaskCards => Set<TaskCard>();
    public DbSet<TaskList> TaskLists => Set<TaskList>();

    public ToDoDbContext(DbContextOptions options) : base(options)
    {
    }
}