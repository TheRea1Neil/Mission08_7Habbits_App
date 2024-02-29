using System;
using System.Collections.Generic;

namespace Mission08_7Habbits_App.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CatName { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
