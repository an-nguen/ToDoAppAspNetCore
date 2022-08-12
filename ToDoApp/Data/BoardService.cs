using Microsoft.EntityFrameworkCore;
using ToDoApp.Domains;

namespace ToDoApp.Data;

public class BoardService
{
    private readonly IDbContextFactory<ToDoDbContext> _contextFactory;
    private readonly ILogger _logger;

    public BoardService(IDbContextFactory<ToDoDbContext> contextFactory, ILogger<BoardService> logger)
    {
        _contextFactory = contextFactory;
        _logger = logger;
    }

    public async Task<List<Board>> FindAll()
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        return await ctx.Boards
            .ToListAsync();
    }

    public async Task<Board?> FindById(int id)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        return await ctx.Boards.FirstOrDefaultAsync(b => b.BoardId == id);
    }

    public async Task CreateBoard(string name)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        ctx.Boards.Add(new Board
        {
            Name = name
        });
        var saved = await ctx.SaveChangesAsync();
        _logger.LogInformation("Saved boards - {Int}", saved);
    }

    public async Task DeleteBoard(int id)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var found = await ctx.Boards
            .Include(b => b.TaskLists)
            .ThenInclude(taskList => taskList.Cards)
            .FirstOrDefaultAsync(b => b.BoardId == id);
        if (found == null)
            throw new DbDeleteException($"Board with id = {id} not found");
        ctx.Boards.Remove(found!);
        await ctx.SaveChangesAsync();
    }
}