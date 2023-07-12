namespace MobileAPI.Model
{
    public class PurchaseHistory
    {
        public int PurchaseId { get; set; }

        public int MemberId { get; set; }

        public string PurchaseDetails { get; set; }

        public DateTime Date { get; set; }
    }
}
