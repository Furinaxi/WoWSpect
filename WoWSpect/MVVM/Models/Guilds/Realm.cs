﻿namespace WoWSpect.MVVM.Models.Guilds;

public record Realm
{
    public Key key { get; set; }
    public string name { get; set; }
    public int id { get; set; }
    public string slug { get; set; }
}