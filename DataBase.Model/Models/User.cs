using System;
using System.Collections.Generic;

namespace DataBase.Model.Models;

public partial class User
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Email { get; set; }
}
