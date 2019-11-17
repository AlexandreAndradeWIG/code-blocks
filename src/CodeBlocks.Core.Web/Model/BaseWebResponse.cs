using CodeBlocks.Core.Model;

namespace CodeBlocks.Core.Web.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseWebResponse : Result, IWebResult
    {
        /// <summary>
        /// StatusCode of the result.
        /// </summary>
        public string StatusCode { get; set; }



        public BaseWebResponse()
        {

        }

        public BaseWebResponse(bool success) : base(success)
        {

        }
    }
}
