namespace My_Twitter_Clone_Backend.Models
{
    public class LikedTweet
    {
        public int Id { get; set; }
        public int TweetId { get; set; }
        public int UserId { get; set; }
        public User ?User { get; set; }
    }
}
