using Microsoft.AspNetCore.Mvc;
using MobileAPI.Model;
using MobileAPI.Service.IService;
using System.Security.Cryptography;
using System.Text;

namespace MobileAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;

        private static Dictionary<string, string> activeSessions = new Dictionary<string, string>();

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpPost("register")]
        public IActionResult RegisterMember(Member model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                _memberService.RegisterMember(model);
            }
            // Generate and store an OTP code for the member
            string otpCode = GenerateRandomOTP(10);
            _memberService.SaveOTPCodeToDatabase(model.MemberId, otpCode);

            return Ok(new { Message = "Member registered successfully. Please verify the OTP." });
        }

        [HttpPost("login")]
        public IActionResult Login(Member model)
        {
            // Check if member is already logged in on another device
            if (activeSessions.ContainsKey(Convert.ToString(model.MemberId)))
            {
                activeSessions.Remove((Convert.ToString(model.MemberId)));
            }

            activeSessions.Add((Convert.ToString(model.MemberId)), model.DeviceId);

            return Ok(new { Message = "Login successful." });
        }

        [HttpGet("GetPurchaseHistory")]
        public IActionResult GetPurchaseHistory(int id)
        {
            _memberService.GetPurchaseHistory(id);

            return Ok();
        }

        string GenerateRandomOTP(int length)
        {
            const string allowedChars = "1234567890";
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] buffer = new byte[length];
                rng.GetBytes(buffer);
                var otp = new StringBuilder(length);
                foreach (var bytes in buffer)
                {
                    otp.Append(allowedChars[bytes % allowedChars.Length]);
                }
                return otp.ToString();
            }
        }

    }
}