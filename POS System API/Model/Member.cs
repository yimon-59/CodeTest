namespace POS_System_API.Model
{
    public class Member
    {
        public string MemberCode { get; set; }

        public int Point { get; set; }
        public List<Products> ProductItems { get; set; }
    }
}
