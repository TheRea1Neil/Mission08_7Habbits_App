using System;
using System.Collections.Generic;

namespace Mission08_7Habbits_App.Models;

public partial class Task
{
    public int TaskId { get; set; }

    public string Title { get; set; } = null!;

    public DateTime? DueDate { get; set; }

    public int Quadrant { get; set; }

    public int? CategoryId { get; set; }

    public bool Completed { get; set; }

    public virtual Category? Category { get; set; }
}
