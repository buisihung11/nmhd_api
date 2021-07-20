using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NMHD_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NuocMamHongDuc_Web_App.Controllers
{
    [Route("api/blogposts")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly NMHDDbContext _context;
        public BlogPostController(NMHDDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<BlogPost>>> GetBlogPosts(int blogPostType = -1)
        {
            List<BlogPost> blogposts = await _context.BlogPosts.Where((b) => blogPostType == -1|| (int)b.BlogPostType == blogPostType)
                .ToListAsync();
            return blogposts;
        }

        [HttpPost]
        public BlogPost CreateBlogPost(BlogPost blogPost)
        {
            _context.Add(blogPost);
            _context.SaveChanges();
            return blogPost;
        }

        [HttpPut("{id}")]
        public ActionResult<BlogPost> UpdateBlogPost(int id, BlogPost blogPost)
        {
            if(id != blogPost.Id)
            {
                return BadRequest();
            }

            _context.BlogPosts.Update(blogPost);
            _context.SaveChanges();
            return blogPost;
        }
        
        [HttpDelete("{id}")]
        public ActionResult<BlogPost> DeleteBlogPost(int id)
        {
            var blogPost = _context.BlogPosts.FirstOrDefault((b) => b.Id == id);
            if(blogPost != null)
            {
                return NotFound();
            }

            _context.BlogPosts.Remove(blogPost);
            _context.SaveChanges();
            return blogPost;
        }
    }
}
