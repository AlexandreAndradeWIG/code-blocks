using WIG.Core.Model;

namespace Web.Generics.Core
{
    public class BaseWebResponse : Result
    {
        public BaseWebResponse()
        {

        }
        public BaseWebResponse(bool success) : base(success)
        {

        }
    }


    public class APIResponse : BaseWebResponse
    {
        public string StatusCode { get; set; }
    }
}
