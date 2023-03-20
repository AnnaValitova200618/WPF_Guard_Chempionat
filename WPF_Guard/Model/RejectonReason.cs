using System;
using System.Collections.Generic;

namespace WPF_Guard.Model;

public partial class RejectonReason
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Request> Requests { get; } = new List<Request>();
}
