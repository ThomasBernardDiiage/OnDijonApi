﻿using System;
namespace OnDijon.Models.Requests.Address;

public class PartialUpdateAddressByIdCommand
{
    public string Name { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Phone { get; set; }
}

