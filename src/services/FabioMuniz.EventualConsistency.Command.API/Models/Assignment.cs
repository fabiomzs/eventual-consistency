namespace FabioMuniz.EventualConsistency.Command.API.Models;

public class Assignment
{
    public Guid Id { get; set; }
    public string? Description { get; set; }
    public bool Completed { get; set; }
    public DateTime CreatedAt { get; set; }
       

    public Assignment(string description)
    {
        Id = Guid.NewGuid();
        Description = description;
        Completed = false;
    }

    public Assignment(Guid id, string description, bool completed)
    {
        Id= id;
        Description = description;
        Completed = completed;
    }
}
