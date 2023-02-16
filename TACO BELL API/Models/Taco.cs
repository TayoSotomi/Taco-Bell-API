using System;
using System.Collections.Generic;

namespace TACO_BELL_API.Models;

public partial class Taco
{
    private bool bean;

    public Taco(string name, float cost, bool softshell, bool dorito)
    {
        Name = name;
        Cost = cost;
        SoftShell = softshell;
        Dorito = dorito;
    }

    public int Id { get; set; }

    public string? Name { get; set; }

    public float? Cost { get; set; }

    public bool? SoftShell { get; set; }

    public bool? Dorito { get; set; }
}
