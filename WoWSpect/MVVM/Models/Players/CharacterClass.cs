﻿namespace WoWSpect.MVVM.Models.Players;

public record CharacterClass
{
    public Key key { get; set; }
    public string name { get; set; }
    public int id { get; set; }
}