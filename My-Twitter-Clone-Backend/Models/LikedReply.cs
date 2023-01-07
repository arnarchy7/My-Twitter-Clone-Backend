namespace My_Twitter_Clone_Backend.Models
{
    public class LikedReply
    {
        public int Id { get; set; }
        public int ReplyId { get; set; }
        public int UserId { get; set; }
        public User ?User { get; set; }
    }
}
