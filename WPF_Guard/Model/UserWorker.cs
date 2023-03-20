using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WPF_Guard.Model;

public partial class UserWorker
{
    

    public int Id { get; set; }

    public string? Fio { get; set; }

    public string? Sex { get; set; }

    public int? IdPosition { get; set; }

    public int? IdType { get; set; }

    public string? Word { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public byte[]? Image { get; set; }

    public byte? Approved { get; set; }

    public byte? AddData { get; set; }

    public byte? ViewingData { get; set; }

    public byte? EditData { get; set; }

    public virtual Position? IdPositionNavigation { get; set; }

    public virtual Type? IdTypeNavigation { get; set; }

    [NotMapped]
    public bool ApprovedBool
    {
        get => Approved == 1;
        set => Approved = value ? (byte?)1 : (byte?)0;
    }

    [NotMapped]
    public bool AddDataBool 
    {
        get => AddData == 1; 
        set => AddData = value ? (byte)1 : (byte)0; 
    }

    [NotMapped]
    public bool EditDataBool
    {
        get => EditData == 1;
        set => EditData = value ? (byte?)1 : (byte)0;
    }
    [NotMapped]
    public bool ViewingDataBool
    {
        get=> ViewingData == 1;
        set=> ViewingData = value ? (byte?)1 : (byte)0;
    }
}
