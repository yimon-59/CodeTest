using MobileAPI.Model;

namespace MobileAPI.Repository.IRepository
{
    public interface IMemberRepository
    {
        void RegisterMember(Member memberModel);
        void SaveOTPCodeToDatabase(int id, string otp);
        PurchaseHistory GetPurchaseHistory(int id);
    }
}
