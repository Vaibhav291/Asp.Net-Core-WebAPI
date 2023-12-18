using Code_to_Build.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Code_to_Build.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : Controller
    {
        public readonly CodetoBuildDbContext _context;

        public BlogController(CodetoBuildDbContext context)
        {
            _context = context;
        }

        [HttpPost("blog/Add")]
        public async Task<IActionResult> AddBlog([FromBody] Blog blog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();

            return Ok("Blog Posted Successfully");
        }

        [HttpPut("blog/Edit/{id}")]
        public async Task<IActionResult> EditBlog(int id, [FromBody] Blog blog)
        {
            var blogUpdate = await _context.Blogs.FindAsync(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (blogUpdate == null)
            {
                return NotFound($"Blog with Id = {id} not found");
            }

            blogUpdate.Title = blog.Title;
            blogUpdate.Content = blog.Content;

            _context.Blogs.Update(blogUpdate);
            await _context.SaveChangesAsync();

            return Ok("Blog updated successfully");
        }

        [HttpDelete("blog/delete/{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var deleteBlog = await _context.Blogs.FindAsync(id);

            if (deleteBlog == null)
            {
                return NotFound($"Blog with Id = {id} not found");
            }

            _context.Blogs.Remove(deleteBlog);
            await _context.SaveChangesAsync();

            return Ok("Blog is Deleted");
        }

        [HttpGet("AllBlogs")]
        public async Task<IActionResult> GetAllBlogs()
        {
            var allBlog = await _context.Blogs.ToListAsync();
            return Ok(allBlog);
        }

        [HttpPost]
        public async Task<IActionResult> AddFeedback([FromBody] Blog blog)
        {
            var feedback = await _context.Blogs.FindAsync(blog.Id);

            feedback.Like = blog.Like + 1;
            feedback.Comments = blog.Comments;

            _context.Blogs.Add(feedback);
            await _context.SaveChangesAsync();
            return Ok("Feedback updated");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFeedback([FromBody] Blog blog) 
        {
            var feedback = await _context.Blogs.FindAsync(blog.Id);
            
            feedback.Like = blog.Like - 1;
            feedback.Comments = blog.Comments;

            _context.Blogs.Update(feedback);
            await _context.SaveChangesAsync();
            return Ok("Feedback Added");
        }
    }
}
