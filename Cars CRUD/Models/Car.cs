﻿namespace Cars_CRUD.Models;

public class Car
{
    public Guid Id { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string Color { get; set; }
}
