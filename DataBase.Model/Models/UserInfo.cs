using System;
using System.Collections.Generic;

namespace DataBase.Model.Models;

public partial class UserInfo
{
    public long Id { get; set; }

    public int UserId { get; set; }

    public string Email { get; set; } = null!;
}
