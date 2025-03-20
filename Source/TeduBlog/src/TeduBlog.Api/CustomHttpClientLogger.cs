using Microsoft.Extensions.Http.Logging;

namespace TeduBlog.Api
{
    /// <summary>
    /// Tự động ghi log cho HTTP Client khi gửi request và nhận response
    /// </summary>
    public class CustomHttpClientLogger : IHttpClientLogger
    {
        private readonly ILogger<CustomHttpClientLogger> _logger;
        public CustomHttpClientLogger(ILogger<CustomHttpClientLogger> logger = null)
        {
            _logger = logger;
        }
        public void LogRequest(HttpRequestMessage request)
        {
            // Ghi log thông tin yêu cầu HTTP
            Console.WriteLine($"Sending {request.Method} request to {request.RequestUri}");
            _logger.LogInformation($"Sending {request.Method} request to {request.RequestUri}");
        }

        public object? LogRequestStart(HttpRequestMessage request)
        {
            Console.WriteLine($"[START] {request.Method} {request.RequestUri}");
            _logger.LogInformation($"[START] {request.Method} {request.RequestUri}");
            return null; // Trả về context nếu cần, ở đây để null
        }

        public void LogRequestStop(object? context, HttpRequestMessage request, HttpResponseMessage response, TimeSpan elapsed)
        {
            Console.WriteLine($"[STOP] {request.Method} {request.RequestUri} - {response.StatusCode} in {elapsed.TotalMilliseconds}ms");
            _logger.LogInformation($"[STOP] {request.Method} {request.RequestUri} - {response.StatusCode} in {elapsed.TotalMilliseconds}ms");
        }

        public void LogRequestFailed(object? context, HttpRequestMessage request, HttpResponseMessage? response, Exception exception, TimeSpan elapsed)
        {
            Console.WriteLine($"[FAILED] {request.Method} {request.RequestUri} - Error: {exception.StackTrace} after {elapsed.TotalMilliseconds}ms");
            _logger.LogError($"[FAILED] {request.Method} {request.RequestUri} - Error: {exception.StackTrace} after {elapsed.TotalMilliseconds}ms");
        }

        public void LogResponse(HttpResponseMessage response)
        {
            // Ghi log thông tin phản hồi HTTP
            Console.WriteLine($"Received {response.StatusCode} response from {response.RequestMessage.RequestUri}");
            _logger.LogInformation($"Received {response.StatusCode} response from {response.RequestMessage.RequestUri}");
        }
    }
}
