namespace My_Twitter_Clone_Backend.Models
{
    public class Reply
    {
        public int ?Id { get; set; }
        public int ?UserId { get; set; }
        public User ?User { get; set; }
        public int ?TweetId { get; set; }
        public Tweet ?Tweet { get; set; }
        public string ?Body { get; set; }
        public DateTime ?CreatedAt { get; set; }
        public int ?RetweetCount { get; set; }
        public int ?LikeCount { get; set; }

    }
}
