using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoApp.Domains;

public class TaskCard
{
    public int TaskCardId { get; set; }
    [Column(TypeName = "nvarchar(100)")]
    public string Label { get; set; } = "";
    [Column(TypeName = "nvarchar(30000)")]
    public string? Description { get; set; }
    // Position Field need for arrange items in right order
    public int Position { get; set; }

    public string? CoverColor { get; set; } = "";
    
    public int TaskListId { get; set; }
    public TaskList? TaskList { get; set; }
}