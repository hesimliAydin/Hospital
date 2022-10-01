using System.Collections.Generic;

class Hospital
{
    public Dictionary<string, List<Doctor>> Departments { get; set; } = new Dictionary<string, List<Doctor>>();
}
