using System.Net;

namespace BlazorUI.Services
{
    public class ApiResponse<T>
    {
        /// <summary>
        /// Indicates whether the request was successful or not.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Provides more details about an error if the request was not successful.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// The data returned from the request (can be any type).
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// The HTTP status code associated with the response.
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        public bool Completed { get; set; }
    }
}
