using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistenc;

namespace API.Controllers {

    [ApiController]
    [Route("api/[controller]")]

    public class PostsController : ControllerBase {
        private readonly DataContext context;

        public PostsController(DataContext context){
            this.context = context;
        }

        //get api/posts
        [HttpGet(Name = "GetPosts")]
        public ActionResult<List<Post>> Get (){
            return this.context.Posts.ToList();
        }

        [HttpGet("{id}", Name = "GetById")]

        public ActionResult<Post> GetById(Guid id)
        {
            var post = this.context.Posts.Find(id);
            if (post is null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        [HttpGet(Name = "Create")]

        public ActionResult<Post> Create([FromBody]Post request)
        {
            var post = new Post
            {
                Id = request.Id,
                Title = request.Title,
                Body = request.Body,
                Date = request.Date
            };

            context.Posts.Add(post);
            var success = context.SaveChanges() > 0;

            if (success)
            {
                return Ok(post);
            }

            throw new Exception("Error creating post");
        }
    }
}