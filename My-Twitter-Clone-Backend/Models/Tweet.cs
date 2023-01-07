namespace My_Twitter_Clone_Backend.Models
{
    public class Tweet
    {


        public int ?Id { get; set; }
        public string TweetBody { get; set; }
        public DateTime TweetCreated { get; set; }
        public int UserId { get; set; }
        public User ?User { get; set; }
        public int ?RetweetCount { get; set; }
        public int ?LikeCount { get; set; }

        public ICollection<Reply> ?Replies { get; set; }

    }
}
