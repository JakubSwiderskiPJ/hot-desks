﻿namespace HotDesks.Models;

public class Employee
{
    public string Id { get; set; }
    public string name { get; set; }
    public ICollection<Reservation> Reservations { get; set; }
}