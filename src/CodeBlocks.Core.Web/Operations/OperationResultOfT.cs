using CodeBlocks.Core.Model;
using System.Collections.Generic;
using System.Linq;

namespace CodeBlocks.Web.Operations
{
    public class OperationResult<T> : Result<T>
    {
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        [System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
        public ResultStatus Status { get; set; } = ResultStatus.Ok;


        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public string UserMessage
        {
            get
            {
                if (Status == ResultStatus.Invalid)
                {
                    return Messages?.FirstOrDefault(m => m.Type == ResultMessageType.Error)?.Content;
                }

                if (Status == ResultStatus.Error || Status == ResultStatus.NotFound || Status == ResultStatus.Unauthorized)
                {
                    return Messages?.FirstOrDefault(m => m.Type == ResultMessageType.Error)?.Content;
                }

                if (Status == ResultStatus.Ok)
                {
                    return Messages?.FirstOrDefault(m => m.Type == ResultMessageType.Success)?.Content;
                }

                return null;
            }
        }


        public OperationResult() : base()
        {
        }
        public OperationResult(T value) : base(value)
        {
        }
        public OperationResult(ResultStatus status, T value = default, List<ResultMessage> resultMessages = null, List<ValidationError> validationErrors = null) : base(status == ResultStatus.Ok, value, resultMessages, validationErrors)
        {
            Status = status;
        }


        #region Static Builders

        public static OperationResult<T> Ok(T value)
        {
            return new OperationResult<T>(value);
        }

        public static OperationResult<T> Ok(T value, params string[] messages)
        {
            var resultMessages = messages.Select(error => new ResultMessage
            {
                Content = error,
                Type = ResultMessageType.Success
            }).ToList();

            return new OperationResult<T>(ResultStatus.Ok, value, resultMessages);
        }

        public static OperationResult<T> Error(List<ResultMessage> errors = null)
        {
            return new OperationResult<T>(ResultStatus.Error, default, errors);
        }

        public static OperationResult<T> Error(params string[] errors)
        {
            var resultMessages = errors.Select(error => new ResultMessage
            {
                Content = error,
                Type = ResultMessageType.Error
            }).ToList();

            return new OperationResult<T>(ResultStatus.Error, default, resultMessages);
        }

        public static OperationResult<T> NotFound()
        {
            return new OperationResult<T>(ResultStatus.NotFound);
        }

        public static OperationResult<T> NotFound(params string[] errors)
        {
            var resultMessages = errors.Select(error => new ResultMessage
            {
                Content = error,
                Type = ResultMessageType.Error
            }).ToList();

            return new OperationResult<T>(ResultStatus.NotFound, default, resultMessages);
        }

        public static OperationResult<T> Unauthorized()
        {
            return new OperationResult<T>(ResultStatus.Unauthorized);
        }

        public static OperationResult<T> Unauthorized(params string[] errors)
        {
            var resultMessages = errors.Select(error => new ResultMessage
            {
                Content = error,
                Type = ResultMessageType.Error
            }).ToList();

            return new OperationResult<T>(ResultStatus.Unauthorized, default, resultMessages);
        }

        public static OperationResult<T> Invalid(List<ValidationError> validationErrors = null)
        {
            return new OperationResult<T>(ResultStatus.Invalid, default, null, validationErrors);
        }

        #endregion
    }
}
