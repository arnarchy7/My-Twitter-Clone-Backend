using System.ComponentModel.DataAnnotations.Schema;

namespace My_Twitter_Clone_Backend.Models
{
    public class User
    {
       
        public int ?UserId { get; set; }
        public string ?DisplayName { get; set; }
        public string ?ImageURL { get; set; }
        public string ?Handle { get; set; }

        
        public ICollection<LikedTweet> ?LikedTweets { get; set; }
        
        public ICollection<LikedReply> ?LikedReplies { get; set; }  

        public ICollection<Tweet> ?Tweets { get; set; }

        public ICollection<Reply> ?Replies { get; set; }
    }
}
