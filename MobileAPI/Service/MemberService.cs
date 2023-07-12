using MobileAPI.Model;
using MobileAPI.Repository.IRepository;

namespace MobileAPI.Service
{
    public class MemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public void RegisterMember(Member memberModel)
        {
            _memberRepository.RegisterMember(memberModel);
        }

        public void SaveOTPCodeToDatabase(int id, string otp)
        {
            _memberRepository.SaveOTPCodeToDatabase(id,otp);
        }
    }
}
