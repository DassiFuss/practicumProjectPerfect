﻿using System;
using System.Collections.Generic;

namespace Properties.Entities;

public partial class User
{
    public int IdUser { get; set; }

    public string IdFamily { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string Id { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public int? IdSex { get; set; }

    public int? IdHmo { get; set; }

    public int? IdStatus { get; set; }

    public virtual Hmo? IdHmoNavigation { get; set; }

    public virtual Sex? IdSexNavigation { get; set; }

    public virtual Status? IdStatusNavigation { get; set; }
}


