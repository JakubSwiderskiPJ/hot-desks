﻿namespace HotDesks.Models;

public class Reservation
{
    public int Id { get; set; }
    public int DeskId { get; set; }
    public Desk Desk { get; set; }
    public string EmployeeId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}