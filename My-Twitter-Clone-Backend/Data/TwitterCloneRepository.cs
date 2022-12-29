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
    }
}
