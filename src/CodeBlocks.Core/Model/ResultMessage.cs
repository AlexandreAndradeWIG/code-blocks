namespace CodeBlocks.Core.Model
{
    public class ResultMessage
    {
        public string Content { get; set; }
        public string Code { get; set; }
        public ResultMessageType Type { get; set; }


        public static ResultMessage Error(string message, string code = null)
        {
            return new ResultMessage
            {
                Type = ResultMessageType.Error,
                Code = code,
                Content = message
            };
        }

        public static ResultMessage Success(string message, string code = null)
        {
            return new ResultMessage
            {
                Type = ResultMessageType.Success,
                Code = code,
                Content = message
            };
        }

        public static ResultMessage Warning(string message, string code = null)
        {
            return new ResultMessage
            {
                Type = ResultMessageType.Warning,
                Code = code,
                Content = message
            };
        }

        public static ResultMessage Information(string message, string code = null)
        {
            return new ResultMessage
            {
                Type = ResultMessageType.Information,
                Code = code,
                Content = message
            };
        }
    }
}
