namespace FabioMuniz.EventualConsistency.Blazor.Models;

public record Assignment(Guid Id, string? Description, bool Completed, DateTime CreatedAt);