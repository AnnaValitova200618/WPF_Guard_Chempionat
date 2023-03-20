using System;
using System.Collections.Generic;

namespace WPF_Guard.Model;

public partial class PersonalVisit
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public DateTime? TimeStart { get; set; }

    public DateTime? TimeEnd { get; set; }

    public int? IdRequest { get; set; }

    public DateTime? TimeSubdvisionStart { get; set; }

    public DateTime? TimeSubdvisionEnd { get; set; }

    public int? IdAccess { get; set; }

    public virtual Request? IdRequestNavigation { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;
}
