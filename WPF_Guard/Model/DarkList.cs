using System;
using System.Collections.Generic;

namespace WPF_Guard.Model;

public partial class DarkList
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public string Reason { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
