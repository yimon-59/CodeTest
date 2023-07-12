namespace MobileAPI.Model
{
    public class MemberCoupon
    {
        public int MemberId { get; set; }

        public int CouponId { get; set; }

        public DateTime RedemptionDate { get; set; }
    }
}
