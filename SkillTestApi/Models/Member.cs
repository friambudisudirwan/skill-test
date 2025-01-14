using System;

namespace SkillTestApi.Models;

public class Member
{
    public int TipeMember { get; set; }
    public string? JenisMember { get; set; }
    public double GetDiscount(double totalBelanja, int pointReward)
    {
        var discount = 0d;

        if (pointReward >= 100 && pointReward <= 300)
        {
            if (TipeMember == 1)
            {
                discount = totalBelanja * (50d / 100d) + 35;
            }
            else if (TipeMember == 2)
            {
                discount = totalBelanja * (50d / 100d) + 50;
            }
            else if (TipeMember == 3)
            {
                discount = totalBelanja * (50d / 100d) + 68;
            }
        }
        else if (pointReward >= 301 && pointReward <= 500)
        {
            if (TipeMember == 1)
            {
                discount = totalBelanja * (50d / 100d) + 35;
            }
            else if (TipeMember == 2)
            {
                discount = totalBelanja * (25d / 100d) + 34;
            }
            else if (TipeMember == 3)
            {
                discount = totalBelanja * (25d / 100d) + 52;
            }
        }
        else if (pointReward > 500)
        {
            if (TipeMember == 1)
            {
                discount = totalBelanja * (50d / 100d) + 35;
            }
            else if (TipeMember == 2)
            {
                discount = totalBelanja * (25d / 100d) + 25;
            }
            else if (TipeMember == 3)
            {
                discount = totalBelanja * (10d / 100d) + 39;
            }
        }

        return discount;
    }
}
