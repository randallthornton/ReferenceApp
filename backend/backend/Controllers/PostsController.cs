using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/posts")]
    [ApiController]
    [Authorize]
    public class PostsController : ControllerBase
    {
        ApplicationDbContext applicationDbContext;

        public PostsController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public async Task<ActionResult> GetPosts()
        {
            var posts = await applicationDbContext.Posts.ToListAsync();

            return Ok(posts);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePost([FromBody] CreatePostRequest request)
        {
            var post = new Post
            {
                Title = request.Title,
                Content = request.Content,
                CreatedBy = HttpContext.User.Identity.Name,
                CreatedDate = DateTimeOffset.Now,
            };

            applicationDbContext.Posts.Add(post);

            await applicationDbContext.SaveChangesAsync();

            return Ok(request);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> UpdatePost(int id, [FromBody] CreatePostRequest request)
        {
            var post = await applicationDbContext.Posts.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            var username = HttpContext.User.Identity.Name;

            if (!string.Equals(username, post.CreatedBy, StringComparison.InvariantCultureIgnoreCase))
            {
                return Forbid();
            }

            post.Title = request.Title;
            post.Content = request.Content;

            await applicationDbContext.SaveChangesAsync();

            return Accepted(post);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeletePost(int id)
        {
            var post = await applicationDbContext.Posts.SingleOrDefaultAsync(x => x.PostId == id);

            if (post == null)
            {
                NotFound();
            }

            applicationDbContext.Posts.Remove(post);

            await applicationDbContext.SaveChangesAsync();

            return Accepted();
        }
    }
}
