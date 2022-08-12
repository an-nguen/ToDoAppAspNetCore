using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoApp.Domains;

public class TaskList
{
    public int TaskListId { get; set; }
    [Column(TypeName = "nvarchar(100)")]
    public string Label { get; set; } = "";
    // Position Field need for arrange items in right order
    public int Position { get; set; }

    public List<TaskCard>? Cards { get; set; }
    
    public int BoardId { get; set; }
    public Board? Board { get; set; }
}