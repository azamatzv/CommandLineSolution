﻿using System.ComponentModel.DataAnnotations;

namespace CommandLine.Dtos;

public class CommandCreatedDto
{
    [Required]
    [MaxLength(250)]
    public string? HowTo { get; set; }

    [Required]
    public string? Platform { get; set; }

    [Required]
    public string? CommandLine { get; set; }
}
