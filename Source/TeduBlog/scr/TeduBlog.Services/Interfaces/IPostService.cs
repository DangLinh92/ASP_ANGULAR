using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduBlog.Core.Domain.Content;
using TeduBlog.Services.Models;

namespace TeduBlog.Services.Interfaces
{
    public interface IPostService
    {
        Task<int> Save();
        Task<Post> GetPostById(Guid id);
        Task<List<Post>> GetPopularPostsAsync(int count);
        Task<PagedResult<Post>> GetPostsPagingAsync(string keyword, Guid? categoryId, int pageIndex = 1, int pageSize = 10);

        Post CreatePost(Post post);
        Post UpdatePost(Post post);
        Task DeletePost(Guid id);
    }
}
