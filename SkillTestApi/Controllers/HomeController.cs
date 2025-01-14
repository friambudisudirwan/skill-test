using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillTestApi.Database;
using SkillTestApi.Models;
namespace SkillTestApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class HomeController : Controller
    {
        private readonly DBContext _context;
        public HomeController(DBContext context)
        {
            _context = context;
        }
        [HttpPost]
        [Route("API/SplitAndReverseString")]
        [ProducesResponseType<string>(StatusCodes.Status200OK)]
        public string SplitAndReverseString([Required] string input)
        {
            var nilaiTengah = input.Length / 2;
            var stringList = new List<string>() { input.Substring(0, nilaiTengah) };

            if (input.Length % 2 == 0)
            {
                stringList.Add(input.Substring(nilaiTengah, input.Length - nilaiTengah));
            }
            else
            {
                stringList.Add(input.Substring(nilaiTengah, 1));
                stringList.Add(input.Substring(nilaiTengah + 1, input.Length - nilaiTengah - 1));
            }

            var result = "";
            foreach (var x in stringList)
            {
                for (var i = x.Length; i > 0; i--)
                {
                    result += x[i - 1];
                }
            }

            return result;
        }

        [HttpPost]
        [Route("API/Anagram")]
        [ProducesResponseType<string>(StatusCodes.Status200OK)]
        public string Anagram([FromBody] AnagramParam param)
        {
            if (param.FirstWords.Count != param.SecondWords.Count)
            {
                Response.StatusCode = StatusCodes.Status400BadRequest;
                return "Length parameter firstWords dan secondWords tidak sama";
            }
            ;

            var firstWords = param.FirstWords.Select(x => string.Concat(x.ToLower().OrderBy(y => y))).ToArray();
            var secondWords = param.SecondWords.Select(x => string.Concat(x.ToLower().OrderBy(y => y))).ToArray();

            var result = "";

            for (var i = 0; i < firstWords.Length; i++)
            {
                if (firstWords[i] == secondWords[i])
                {
                    result += "1";
                }
                else
                {
                    result += "0";
                }
            }

            return result;
        }

        [HttpPost]
        [Route("API/CalculateDiscount")]
        [ProducesResponseType<string>(StatusCodes.Status201Created)]
        public Transaksi CalculateDiscount([FromBody] Transaksi param)
        {
            var listMember = new List<KeyValuePair<int, string>>()
            {
                new(1, "platinum"),
                new(2, "gold"),
                new(3, "silver")
            };

            var getTipeMember = listMember.FirstOrDefault(x => x.Value.ToLower().Equals(param.TipeCustomer));
            if (getTipeMember.Equals(new KeyValuePair<int, string>()))
            {
                Response.StatusCode = StatusCodes.Status400BadRequest;
                return new Transaksi();
            }

            var member = new Member() { TipeMember = getTipeMember.Key, JenisMember = getTipeMember.Value };
            var diskon = member.GetDiscount(param.TotalBelanja, param.PointReward);

            var sequenceTransaksi = 1;
            var lastSequenceTransaksi = _context.Transaksi.OrderByDescending(x => x.TransaksiID).FirstOrDefault();
            if (lastSequenceTransaksi is not null) sequenceTransaksi = Convert.ToInt32(lastSequenceTransaksi?.TransaksiID?.Split("_")[1]);

            var transaksiID = (sequenceTransaksi + 1).ToString().PadLeft(4, '0');

            var Transaksi = new Transaksi
            {
                TransaksiID = DateTime.Now.ToString("yyyyMMdd_") + transaksiID,
                TipeCustomer = param.TipeCustomer,
                PointReward = param.PointReward,
                TotalBelanja = param.TotalBelanja,
                Diskon = diskon,
                TotalBayar = param.TotalBelanja - diskon
            };

            var entity = _context.Transaksi.Add(Transaksi);
            _context.SaveChanges();

            return Transaksi;
        }
    }
}
