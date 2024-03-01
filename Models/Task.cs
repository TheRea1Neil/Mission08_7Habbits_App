using System;
using System.Collections.Generic;

namespace Mission08_7Habbits_App.Models;

public partial class Task
{
    public int TaskID { get; set; }

    public string Title { get; set; } = null!;

    public DateTime? DueDate { get; set; }

    public int Quadrant { get; set; }

    public int? CategoryID { get; set; }

    public bool Completed { get; set; }

    public virtual Category? Category { get; set; }
}
