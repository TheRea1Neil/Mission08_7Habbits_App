using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mission08_7Habbits_App.Models;

public partial class Task
{
    [Key]
    [Required]
    public int TaskID { get; set; }
    [Required]
    public string Title { get; set; } = null!;

    public DateTime? DueDate { get; set; }
    [Required]
    public int Quadrant { get; set; }

    public int? CategoryID { get; set; }

    public bool? Completed { get; set; }

    public virtual Category? Category { get; set; } 
}
