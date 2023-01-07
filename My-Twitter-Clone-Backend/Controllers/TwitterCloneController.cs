using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My_Twitter_Clone_Backend.Data;
using My_Twitter_Clone_Backend.Models;
using NuGet.DependencyResolver;
using static System.Net.Mime.MediaTypeNames;

namespace My_Twitter_Clone_Backend.Controllers
{
    [Route("api")]
    [ApiController]
    public class TwitterCloneController : ControllerBase
    {
        private TwitterCloneRepository _repo;

        public TwitterCloneController()
        {
            _repo = new TwitterCloneRepository();
        }

       

        [HttpGet]
        public List<Tweet> GetAllTweets()
        {
            return _repo.GetAllTweets(); 
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Tweet> GetTweetById(int id)
        {
            Tweet? tweet = _repo.GetTweetById(id);
            if(tweet == null)
            {
                return NotFound();
            }
          
            return tweet;
        }
        [HttpGet]
        [Route("users")]
        public List<User> GetAllUsers()
        {
            return _repo.GetAllUsers();
        }

        [HttpGet]
        [Route("users/{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            User? user = _repo.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpGet]
        [Route("replies")]
        public List<Reply> GetAllReplies()
        {
            return _repo.GetAllReplies();
        }

        [HttpGet]
        [Route("replies/{id}")]
        public ActionResult<Reply> GetReplyById(int id)
        {
            Reply? reply = _repo.GetReplyById(id);

            if (reply == null)
            {
                return NotFound();
            }

            return reply;
        }

        [HttpGet]
        [Route("replies/tweet/{id}")]
        public List<Reply> GetRepliesByTweetId(int id)
        {
            return _repo.GetRepliesByTweetId(id);
        }


        [HttpGet]
        [Route("likedtweets")]
        public List<LikedTweet> GetAllLikedTweets()
        {
            return _repo.GetAllLikedTweets();

        }

        [HttpGet]
        [Route("likedtweets/{id}")]
        public ActionResult<LikedTweet> GetLikedTweetById(int id)
        {
            LikedTweet? likedTweet = _repo.GetLikedTweetById(id);

            if (likedTweet == null)
            {
                return NotFound();
            }

            return likedTweet;
        }

        [HttpGet]
        [Route("likedtweets/user/{id}")]
        public List<LikedTweet> GetLikedTweetsByUserId(int id)
        {
            return _repo.GetLikedTweetsByUserId(id);
        }

        [HttpGet]
        [Route("likedtweets/tweet/{id}")]
        public ActionResult<LikedTweet> GetLikedTweetByTweetId(int id)
        {
            LikedTweet? likedTweet = _repo.GetLikedTweetByTweetId(id);

            if (likedTweet == null)
            {
                return NotFound();
            }

            return likedTweet;
        }

        [HttpGet]
        [Route("likedreplies")]
        public List<LikedReply> GetAllLikedReplies()
        {
            return _repo.GetAllLikedReplies();

        }

        [HttpGet]
        [Route("likedreplies/{id}")]
        public ActionResult<LikedReply> GetLikedReplyById(int id)
        {
            LikedReply? likedReply = _repo.GetLikedReplyById(id);

            if (likedReply == null)
            {
                return NotFound();
            }

            return likedReply;
        }

        [HttpGet]
        [Route("likedreplies/replyid/{id}")]
        public ActionResult<LikedReply> GetLikedReplyByReplyId(int id)
        {
            LikedReply? likedReply = _repo.GetLikedReplyByReplyId(id);

            if (likedReply == null)
            {
                return NotFound();
            }

            return likedReply;
        }

        [HttpGet]
        [Route("likedreplies/user/{id}")]
        public List<LikedReply> GetLikedRepliesByUserId(int id)
        {
            return _repo.GetLikedRepliesByUserId(id);
        }

        [HttpPost]
        public ActionResult<Tweet> CreateTweet(Tweet tweet)
        {
            _repo.CreateTweet(tweet);

            return CreatedAtAction(nameof(GetTweetById), new { id=tweet.Id }, tweet);
        }

        [HttpPost]
        [Route("replies")]
        public ActionResult<Reply> CreateReply(Reply reply)
        {
            _repo.CreateReply(reply);

            return CreatedAtAction(nameof(GetReplyById), new { id = reply.Id }, reply);
        }

        [HttpPost]
        [Route("likedtweets")]
        public ActionResult<LikedTweet> CreateLikedTweet(LikedTweet likedTweet)
        {
            _repo.CreateLikedTweet(likedTweet);

            return CreatedAtAction(nameof(GetLikedTweetById), new { id = likedTweet.Id }, likedTweet);
        }

        [HttpPost]
        [Route("likedreplies")]
        public ActionResult<LikedReply> CreateLikedReply(LikedReply likedReply)
        {
            _repo.CreateLikedReply(likedReply);

            return CreatedAtAction(nameof(GetLikedReplyById), new { id = likedReply.Id }, likedReply);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTweet(int id, Tweet Tweet)
        {
            if(id != Tweet.Id)
            {
                return BadRequest();
            }

            try
            {
                Tweet? updated = _repo.UpdateTweet(id, Tweet);

                if(updated == null)
                {
                    return NotFound();
                }

                return NoContent();

            }
            catch (Exception)
            {
                return StatusCode(500);
            }

            
        }

        [HttpPut("replies/{id}")]
        public IActionResult UpdateReply(int id, Reply Reply)
        {
            if (id != Reply.Id)
            {
                return BadRequest();
            }

            try
            {
                Reply? updated = _repo.UpdateReply(id, Reply);

                if (updated == null)
                {
                    return NotFound();
                }

                return NoContent();

            }
            catch (Exception)
            {
                return StatusCode(500);
            }


        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<bool> DeleteTweetById(int id)
        {
            try
            {
                Tweet? tweet = _repo.GetTweetById(id);

                if (tweet == null)
                {
                    return NotFound();
                }

                bool success = _repo.DeleteTweet(tweet);

                if (!success)
                {
                    return StatusCode(500);
                }
               
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            
        }

        [HttpDelete]
        [Route("likedtweets/{id}")]
        public ActionResult<bool> DeleteLikedTweetById(int id)
        {
            try
            {
                LikedTweet? likedTweet = _repo.GetLikedTweetById(id);

                if (likedTweet == null)
                {
                    return NotFound();
                }

                bool success = _repo.DeleteLikedTweet(likedTweet);

                if (!success)
                {
                    return StatusCode(500);
                }

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        [HttpDelete]
        [Route("likedtweets/tweet/{id}")]
        public ActionResult<bool> DeleteLikedTweetByTweetId(int id)
        {

            try
            {
                LikedTweet? likedTweet = _repo.GetLikedTweetByTweetId(id);

                if (likedTweet == null)
                {
                    return NotFound();
                }

                bool success = _repo.DeleteLikedTweet(likedTweet);

                if (!success)
                {
                    return StatusCode(500);
                }

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }



        }

        [HttpDelete]
        [Route("likedreplies/replyid/{id}")]
        public ActionResult<bool> DeleteLikedReplyById(int id)
        {
            try
            {
                LikedReply? likedReply = _repo.GetLikedReplyByReplyId(id);

                if (likedReply == null)
                {
                    return NotFound();
                }

                bool success = _repo.DeleteLikedReply(likedReply);

                if (!success)
                {
                    return StatusCode(500);
                }

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        

    }

}