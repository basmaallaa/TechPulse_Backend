using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechPulse.BL.DTOs;
using TechPulse.BL.Helper;
using TechPulse.BL.Service.Interface;
using TechPulse.DAL.Context;

namespace TechPulse.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly AppDbContext _context;
        public PostController(IPostService postService,AppDbContext context)
        {
            _postService = postService;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _postService.GetAllPostsAsync();

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreatePostDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _postService.CreatePostAsync(dto);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid post ID.");

            var result = await _postService.DeletePostAsync(id);

            if (!result.IsSuccess)
            {
                if (result.Message == "Post not found.")
                    return NotFound(result);

                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
