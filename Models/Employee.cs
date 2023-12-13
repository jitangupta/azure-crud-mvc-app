using System;
using System.Collections.Generic;

namespace AzureCrudMvcApp.Models;

public partial class Employee
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public DateTime? DateOfJoining { get; set; }

    public int? DeptId { get; set; }

    public virtual Department? Dept { get; set; }
}
