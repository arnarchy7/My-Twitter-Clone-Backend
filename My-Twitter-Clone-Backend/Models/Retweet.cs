namespace My_Twitter_Clone_Backend.Models
{
    public class Retweet
    {
        public int RetweetId { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime RetweetCreated { get; set; }
    }
}
