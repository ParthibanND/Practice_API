﻿using System;
using System.Collections.Generic;

namespace DataBase.Model.Models;

public partial class Country
{
    public int Id { get; set; }

    public string Iso { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string NiceName { get; set; } = null!;

    public string? Iso3 { get; set; }

    public int? NumCode { get; set; }

    public int PhoneCode { get; set; }
}
