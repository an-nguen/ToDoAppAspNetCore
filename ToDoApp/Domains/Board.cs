using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoApp.Domains;

public class Board
{
    public int BoardId { get; set; }
    [Column(TypeName = "nvarchar(100)")]
    public string Name { get; set; } = "";
    public List<TaskList> TaskLists { get; set; } = new();
}