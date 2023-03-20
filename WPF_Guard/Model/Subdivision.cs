using System;
using System.Collections.Generic;

namespace WPF_Guard.Model;

public partial class Subdivision
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Worker> Workers { get; } = new List<Worker>();
}
