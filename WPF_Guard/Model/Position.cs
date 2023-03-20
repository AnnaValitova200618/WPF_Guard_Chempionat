using System;
using System.Collections.Generic;

namespace WPF_Guard.Model;

public partial class Position
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<UserWorker> UserWorkers { get; } = new List<UserWorker>();
}
