using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduBlog.Core.Domain.Content;
using TeduBlog.Core.SeedWorks;
using TeduBlog.Services.Interfaces;
using TeduBlog.Services.Models;

namespace TeduBlog.Services.Implementation
{
    public class PostService : BaseService, IPostService
    {
        private readonly IRepository<Post, Guid> _postRepository;
        private IUnitOfWork _unitOfWork;

        public PostService(IRepository<Post, Guid> postRepository, IUnitOfWork unitOfWork)
        {
            _postRepository = postRepository;
            _unitOfWork = unitOfWork;
        }

        public Post CreatePost(Post post)
        {
            _postRepository.Add(post);
            return post;
        }

        public async Task DeletePost(Guid id)
        {
            await _postRepository.Remove(id);
        }

        public async Task<List<Post>> GetPopularPostsAsync(int count)
        {
            var posts = await _postRepository.GetAllAsync();
            return posts.Take(count).ToList();
        }

        public async Task<Post> GetPostById(Guid id)
        {
           return await _postRepository.GetByIdAsync(id);
        }

        public async Task<PagedResult<Post>> GetPostsPagingAsync(string keyword, Guid? categoryId, int pageIndex = 1, int pageSize = 10)
        {
            var post = await _postRepository.GetAllAsync();

            if (!string.IsNullOrEmpty(keyword))
            {
                post = post.Where(x => x.Name.Contains(keyword));
            }

            if (categoryId.HasValue)
            {
                post = post.Where(x => x.CategoryId.Equals(categoryId.Value));
            }

            var totalRow = post.Count();

            post = post.OrderByDescending(x => x.DateCreated).Skip((pageIndex - 1) * pageSize).Take(pageSize);

            return new PagedResult<Post>
            {
                Results = post.ToList(),
                CurrentPage = pageIndex,
                RowCount = totalRow,
                PageSize = pageSize
            };
        }

        public async Task<int> Save()
        {
          return await _unitOfWork.CompleteAsync();
        }

        public Post UpdatePost(Post post)
        {
           _postRepository.Update(post);
            return post;
        }
    }
}
