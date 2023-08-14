using System;
using System.Collections.Generic;

namespace DataBase.Model.Models;

public partial class Project
{
    public long Id { get; set; }

    public int UserId { get; set; }

    public string ProjectCode { get; set; } = null!;
}
