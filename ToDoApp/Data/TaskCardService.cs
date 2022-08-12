using Microsoft.EntityFrameworkCore;
using ToDoApp.Domains;

namespace ToDoApp.Data;

public class TaskCardService
{
    private readonly IDbContextFactory<ToDoDbContext> _contextFactory;

    public TaskCardService(IDbContextFactory<ToDoDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }
    
    public async Task CreateTaskCard(string label, TaskList taskList)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        ctx.TaskCards.Add(new TaskCard
        {
            Label = label,
            TaskListId = taskList.TaskListId,
        });
        await ctx.SaveChangesAsync();
    }

    public async Task RemoveTaskCard(int id)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var found = await ctx.TaskCards.FirstOrDefaultAsync(tl => tl.TaskCardId == id);
        if (found == null)
            throw new DbDeleteException($"TaskCard with id = {id} not found");
        ctx.TaskCards.Remove(found);
        await ctx.SaveChangesAsync();
    }

    public async Task MoveTaskCard(int taskCardId, int taskListId)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var found = await ctx.TaskCards.FirstOrDefaultAsync(tl => tl.TaskCardId == taskCardId);
        if (found == null)
            throw new Exception($"TaskCard with id = {taskCardId} not found");
        found.TaskListId = taskListId;
        await ctx.SaveChangesAsync();
    }
}