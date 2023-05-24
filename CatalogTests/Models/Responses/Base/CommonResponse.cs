using System.Net;

namespace CatalogTests.Models.Responses.Base
{
    public class CommonResponse<T>
    {
        public HttpStatusCode Status;

        public string Content;

        public T Body;
    }
}
