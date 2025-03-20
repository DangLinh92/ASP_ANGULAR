using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Http.Logging;
using System.Net.Http;
using TeduBlog.Api.Models;
using TeduBlog.Core.Domain.Content;
using TeduBlog.Services.Implementation;
using TeduBlog.Services.Interfaces;

namespace TeduBlog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : BaseController
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public PostController(IPostService postService, IMapper mapper, IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _postService = postService;
            _mapper = mapper;
        }

        [HttpGet("test-http")]
        public async Task<IActionResult> TestHttpClient()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://jsonplaceholder.typicode.com/todos/1");

            try
            {
                var httpClient = _httpClientFactory.CreateClient("LoggedClient");

                var startTime = DateTime.UtcNow;
                var response = await httpClient.SendAsync(request);
                var elapsed = DateTime.UtcNow - startTime;

                var content = await response.Content.ReadAsStringAsync();
                return Ok(content);
            }
            catch (Exception ex)
            {
                var elapsed = TimeSpan.FromSeconds(1); // Giả sử thời gian request thất bại
                return StatusCode(500, "Request failed.");
            }
        }

        /// <summary>
        /// Lấy bài Post theo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Post>> Post(Guid id)
        {
            var post = await _postService.GetPostById(id);

            if (post == null)
                return NotFound();

            return Ok(post);
        }

        [HttpGet]
        [Route("paging")]
        public async Task<ActionResult<PageResult>> Paging(string keyword, Guid? categoryId, int pageIndex, int pageSize = 10)
        {
            var result = await _postService.GetPostsPagingAsync(keyword, categoryId, pageIndex, pageSize);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] CreateUpdatePostRequest request)
        {
            var post = _mapper.Map<CreateUpdatePostRequest, Post>(request);

            _postService.CreatePost(post);
            var result = await _postService.Save();

            return result > 0 ? Ok() : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost(Guid id, [FromBody] CreateUpdatePostRequest request)
        {

            var post = await _postService.GetPostById(id);
            if (post == null)
            {
                return NotFound();
            }
            _mapper.Map(request, post);

            var result = await _postService.Save();

            return result > 0 ? Ok() : BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePosts([FromQuery] Guid[] ids)
        {
            foreach (var id in ids)
            {
                await _postService.DeletePost(id);
            }
            var result = await _postService.Save();
            return result > 0 ? Ok() : BadRequest();
        }
    }
}
