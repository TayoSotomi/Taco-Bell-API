using System;
using System.Collections.Generic;

namespace TACO_BELL_API.Models;

public partial class Drink
{
    private bool bean;

    public Drink(string _name, float _cost, bool _slushie)
    {
        Name = _name;
        Cost = _cost;
        Slushie = _slushie;
    }

    public int Id { get; set; }

    public string? Name { get; set; }

    public float? Cost { get; set; }

    public bool? Slushie { get; set; }
}
