using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel.DataAnnotations;
using TeduBlog.Core.Domain.Content;
using AutoMapper;

namespace TeduBlog.Api.Models
{
    public class CreateUpdatePostRequest
    {
        public required string Name { get; set; }

        public required string Slug { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        public string? Thumbnail { get; set; }
        public Guid CategoryId { get; set; }

        public string? Content { get; set; }
        public string? Source { get; set; }

        public string? Tags { get; set; }

        public string? SeoDescription { get; set; }
    }
}
