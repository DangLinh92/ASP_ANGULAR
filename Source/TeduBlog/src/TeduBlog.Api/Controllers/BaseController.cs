using Microsoft.AspNetCore.Mvc;

namespace TeduBlog.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        public ILogger _logger;
    }
}
