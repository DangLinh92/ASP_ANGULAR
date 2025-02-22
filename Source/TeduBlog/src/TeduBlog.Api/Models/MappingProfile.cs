using AutoMapper;
using TeduBlog.Core.Domain.Content;

namespace TeduBlog.Api.Models
{
    /// <summary>
    /// AutoMapper sử dụng Profile để định nghĩa cách map giữa các đối tượng.
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUpdatePostRequest, Post>();  // Map từ CreateUpdatePostRequest → Post
            CreateMap<Post, CreateUpdatePostRequest>();  // Map từ Post → CreateUpdatePostRequest
        }
    }
}
