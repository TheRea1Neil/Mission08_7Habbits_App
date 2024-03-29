﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08_7Habbits_App.Models;

public partial class Task
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TaskID { get; set; }
    [Required(ErrorMessage = "Must give a title")]
    public string Title { get; set; } = null!;

    public DateTime? DueDate { get; set; }
    [Required, Range(1, 4, ErrorMessage = "Must assign to a quadrant")]
    public int Quadrant { get; set; }

    public int? CategoryID { get; set; }

    public bool? Completed { get; set; }

    public virtual Category? Category { get; set; } 
}
