using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeduBlog.Services
{
    public class BaseService
    {
        public IHttpContextAccessor _httpContextAccessor;
    }
}
