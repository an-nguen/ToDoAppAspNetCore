using Microsoft.EntityFrameworkCore;
using ToDoApp.Domains;

namespace ToDoApp.Data;

public class TaskListService
{
    private readonly IDbContextFactory<ToDoDbContext> _contextFactory;

    public TaskListService(IDbContextFactory<ToDoDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<List<TaskList>> LoadTaskList(Board board)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        return await ctx.TaskLists.Include(tl => tl.Cards).Where(taskList => taskList.Board == board).ToListAsync();
    }

    public async Task CreateTaskList(string label, Board board)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        ctx.TaskLists.Add(new TaskList
        {
            Label = label,
            BoardId = board.BoardId,
        });
        await ctx.SaveChangesAsync();
    }

    public async Task RemoveTaskList(int id)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var found = await ctx.TaskLists.Include(tl => tl.Cards).FirstOrDefaultAsync(tl => tl.TaskListId == id);
        if (found == null)
            throw new DbDeleteException($"TaskList with id = {id} not found");
        ctx.TaskLists.Remove(found);
        await ctx.SaveChangesAsync();
    }
}