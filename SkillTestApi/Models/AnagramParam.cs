using System;
using System.ComponentModel.DataAnnotations;

namespace SkillTestApi.Models;

public class AnagramParam
{
    [Required]
    public List<string> FirstWords { get; set; } = [];
    [Required]
    public List<string> SecondWords { get; set; } = [];
}
