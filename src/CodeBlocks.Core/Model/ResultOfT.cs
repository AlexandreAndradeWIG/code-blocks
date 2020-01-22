using System.Collections.Generic;

namespace CodeBlocks.Core.Model
{
    public class Result<T> : Result, IResult<T>
    {
        public Result() : base()
        {

        }
        public Result(T value) : base()
        {
            Value = value;
        }

        public Result(bool success, List<ResultMessage> resultMessages = null) : base(success, resultMessages)
        {
        }

        public Result(bool success, T value, List<ResultMessage> resultMessages = null, List<ValidationError> validationErrors = null) : base(success, resultMessages, validationErrors)
        {
            Value = value;
        }

        public T Value { get; set; }
    }
}
