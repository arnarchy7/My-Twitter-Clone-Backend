namespace My_Twitter_Clone_Backend.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Text { get; set; }
        public DateTime CommentCreated { get; set; }
        public int CommentLikeCount { get; set; }
    }
}
