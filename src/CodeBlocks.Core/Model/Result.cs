using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace CodeBlocks.Core.Model
{
    public class Result : IResult
    {
        public bool Success { get; } = true;

        public List<ValidationError> ValidationErrors { get; } = new List<ValidationError>();
        public List<ResultMessage> Messages { get; } = new List<ResultMessage>();

        [JsonIgnore]
        public List<ResultMessage> SuccessMessages
        {
            get
            {
                return Messages?.Where(m => m.Type == ResultMessageType.Success).ToList();
            }
        }
        [JsonIgnore]
        public List<ResultMessage> ErrorsMessages
        {
            get
            {
                return Messages?.Where(m => m.Type == ResultMessageType.Error).ToList();
            }
        }

        public Result()
        {

        }

        public Result(bool success, List<ResultMessage> resultMessages = null, List<ValidationError> validationErrors = null)
        {
            Success = success;
            if (resultMessages != null)
            {
                Messages.AddRange(resultMessages);
            }
            if (validationErrors != null)
            {
                ValidationErrors.AddRange(validationErrors);
            }
        }
    }

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

        public T Value { get; }
    }

    public class PagedResult<T> : Result, IPagedResult<T>
    {

        public PagedResult() : base()
        {

        }
        public PagedResult(IList<T> value) : base()
        {
            Value = value;
        }

        public PagedResult(bool success, List<ResultMessage> resultMessages = null) : base(success, resultMessages)
        {
        }

        public PagedResult(bool success, IList<T> value, List<ResultMessage> resultMessages = null, List<ValidationError> validationErrors = null) : base(success, resultMessages, validationErrors)
        {
            Value = value;
        }

        public IList<T> Value { get; }
    }
}
