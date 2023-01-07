    using Microsoft.AspNetCore.Mvc;
using My_Twitter_Clone_Backend.Models;

namespace My_Twitter_Clone_Backend.Data

{
    public class TwitterCloneRepository
    {
        private TwitterContext _dbContext;

        public TwitterCloneRepository()
        {
            _dbContext = new TwitterContext();
        }

        public List<Tweet> GetAllTweets()
        {
            return _dbContext.Tweets.ToList();

        }
        public Tweet? GetTweetById(int id)
        {
            return _dbContext.Tweets.Where(t => t.Id == id).FirstOrDefault();
        }

        public List<User> GetAllUsers()
        {
            return _dbContext.Users.ToList();

        }

        public User? GetUserById(int id)
        {
            return _dbContext.Users.Where(t => t.UserId == id).FirstOrDefault();
        }

        public List<Reply> GetAllReplies()
        {
            return _dbContext.Replies.ToList();

        }

        public Reply? GetReplyById(int id)
        {
            return _dbContext.Replies.Where(t => t.Id == id).FirstOrDefault();
        }

        public List<Reply>? GetRepliesByTweetId(int id)
        {
            return _dbContext.Replies.Where(t => t.TweetId == id).ToList();
        }

        public List<LikedTweet> GetAllLikedTweets()
        {
            return _dbContext.LikedTweets.ToList();

        }

        public LikedTweet? GetLikedTweetById(int id)
        {
            return _dbContext.LikedTweets.Where(t => t.Id == id).FirstOrDefault();
        }

        public List<LikedTweet>? GetLikedTweetsByUserId(int id)
        {
            return _dbContext.LikedTweets.Where(t => t.UserId == id).ToList();
        }

        public LikedTweet? GetLikedTweetByTweetId(int id)
        {
            return _dbContext.LikedTweets.Where(t => t.TweetId == id).FirstOrDefault();
        }

        public List<LikedReply> GetAllLikedReplies()
        {
            return _dbContext.LikedReplies.ToList();

        }

        public LikedReply? GetLikedReplyById(int id)
        {
            return _dbContext.LikedReplies.Where(t => t.Id == id).FirstOrDefault();
        }

        public LikedReply? GetLikedReplyByReplyId(int id)
        {
            return _dbContext.LikedReplies.Where(t => t.ReplyId == id).FirstOrDefault();
        }

        public List<LikedReply>? GetLikedRepliesByUserId(int id)
        {
            return _dbContext.LikedReplies.Where(t => t.UserId == id).ToList();
        }

        public void CreateTweet(Tweet Tweet)
        {
            _dbContext.Tweets.Add(Tweet);
            _dbContext.SaveChanges();
        }

        public void CreateReply(Reply Reply)
        {
            _dbContext.Replies.Add(Reply);
            _dbContext.SaveChanges();
        }

        public void CreateLikedTweet(LikedTweet LikedTweet)
        {
            _dbContext.LikedTweets.Add(LikedTweet);
            _dbContext.SaveChanges();
        }

        public void CreateLikedReply(LikedReply LikedReply)
        {
            _dbContext.LikedReplies.Add(LikedReply);
            _dbContext.SaveChanges();
        }

        public Tweet? UpdateTweet(int id, Tweet Tweet)
        {
           
            Tweet edit = GetTweetById(id);

            if (edit == null)
            { return null; }

            
            edit.RetweetCount = Tweet.RetweetCount;
            edit.TweetCreated = Tweet.TweetCreated;
            edit.LikeCount = Tweet.LikeCount;
            edit.TweetBody = Tweet.TweetBody;
            edit.UserId = Tweet.UserId;

            _dbContext.SaveChanges();

            return edit;
        }

        public Reply? UpdateReply(int id, Reply Reply)
        {

            Reply edit = GetReplyById(id);

            if (edit == null)
            { return null; }


            edit.RetweetCount = Reply.RetweetCount;
            edit.CreatedAt = Reply.CreatedAt;
            edit.LikeCount = Reply.LikeCount;
           
            edit.UserId = Reply.UserId;
            edit.TweetId = Reply.TweetId;
            edit.Id = Reply.Id;

            _dbContext.SaveChanges();

            return edit;
        }



        public bool DeleteTweet(Tweet tweet)
        {
            try
            {
                _dbContext.Tweets.Remove(tweet);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

            
            
        }

        public bool DeleteLikedTweet(LikedTweet likedTweet)
        {
            try
            {
                _dbContext.LikedTweets.Remove(likedTweet);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }



        }


        public bool DeleteLikedReply(LikedReply likedReply)
        {
            try
            {
                _dbContext.LikedReplies.Remove(likedReply);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }



        }
    }
}
