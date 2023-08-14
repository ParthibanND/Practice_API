using System;
using System.Collections.Generic;

namespace DataBase.Model.Models;

public partial class Manager
{
    public long Id { get; set; }

    public int UserId { get; set; }

    public string ManagerName { get; set; } = null!;
}
