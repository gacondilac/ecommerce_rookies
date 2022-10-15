namespace ShareView.Model
{
    public class Rating
    {
        public int RatingID { get; set; }
        public int Rate { get; set; } = 5;
        public string Product { get; set; }
        public string User { get; set; }
    }
}
