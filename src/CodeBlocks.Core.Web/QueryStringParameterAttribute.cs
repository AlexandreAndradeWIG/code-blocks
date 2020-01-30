using System;

namespace CodeBlocks.Web
{
    public class QueryStringParameterAttribute : Attribute
    {
        public string Name { get; set; }
    }
}
