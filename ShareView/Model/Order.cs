namespace ShareView.Model
{
    public class Order
    {
        public int OrderID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime OrderDate { get; set; }
        public string Note  { get; set; }
        public int UserID { get; set; }
    }
}
