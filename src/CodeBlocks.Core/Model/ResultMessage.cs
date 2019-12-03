namespace CodeBlocks.Core.Model
{
    public class ResultMessage
    {
        public string Content { get; set; }
        public string Code { get; set; }
        public ResultMessageType Type { get; set; }


        public static ResultMessage ValidationError(string content, string code = null)
        {
            return new ResultMessage
            {
                Code = code,
                Content = content,
                Type = ResultMessageType.ValidationError
            };
        }

    }
}
