using System;
using System.ComponentModel.DataAnnotations;

namespace SkillTestApi.Models;

public class Transaksi
{
    public string? TransaksiID { get; set; }
    [Required]
    public string? TipeCustomer { get; set; }
    [Required]
    public int PointReward { get; set; }
    [Required]
    public double TotalBelanja { get; set; }
    public double Diskon { get; set; }
    public double TotalBayar { get; set; }

}
