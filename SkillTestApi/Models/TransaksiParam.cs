using System;
using System.ComponentModel.DataAnnotations;

namespace SkillTestApi.Models;

public class TransaksiParam
{
    [Required]
    public string? TipeCustomer { get; set; }
    [Required]
    public int PointReward { get; set; }
    [Required]
    public double TotalBelanja { get; set; }
}
