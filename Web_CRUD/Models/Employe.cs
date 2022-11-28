using System;
using System.Collections.Generic;

namespace Web_CRUD.Models;

public partial class Employe
{
    public int Id { get; set; }

    public string Password { get; set; } = null!;

    public DateTime? BirthDay { get; set; }

    public string? Adress { get; set; }

    public string? Email { get; set; }

    public int? Age { get; set; }

    public bool Gender { get; set; }
}
