namespace POS_System_API.Model
{
    public class Member
    {
        public string MemberCode { get; set; }

        public int Point { get; set; }
        public List<Product> ProductItems { get; set; }
    }
}
