namespace My_Twitter_Clone_Backend.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Tweet { get; set; }
        public DateTime TweetCreated { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int CommentCount { get; set; }
        public int LikeCount { get; set; }


    }
}
