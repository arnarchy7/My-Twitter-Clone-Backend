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

    }

}