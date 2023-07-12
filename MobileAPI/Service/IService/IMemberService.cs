using MobileAPI.Model;

namespace MobileAPI.Service.IService
{
    public interface IMemberService
    {
        void RegisterMember(Member member);
        void SaveOTPCodeToDatabase(int id, string otp);
        PurchaseHistory GetPurchaseHistory(int id);
    }
}
