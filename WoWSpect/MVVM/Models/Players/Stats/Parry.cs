﻿namespace WoWSpect.MVVM.Models.Players.Stats;

public record Parry
{
    public int rating { get; set; }
    public double rating_bonus { get; set; }
    public double value { get; set; }
}