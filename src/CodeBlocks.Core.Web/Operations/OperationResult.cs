using CodeBlocks.Core.Model;
using System.Collections.Generic;
using System.Linq;

namespace CodeBlocks.Web.Operations
{

    public class OperationResult : Result, IOperationResult
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

                if (Status == ResultStatus.Error)
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
        public OperationResult(ResultStatus status, List<ResultMessage> resultMessages = null, List<ValidationError> validationErrors = null) : base(status == ResultStatus.Ok, resultMessages, validationErrors)
        {
            Status = status;
        }

        #region Static Builders

        public static OperationResult Ok()
        {
            return new OperationResult();
        }
        public static OperationResult Error(List<ResultMessage> errors = null)
        {
            return new OperationResult(ResultStatus.Error, errors);
        }
        public static OperationResult Error(params string[] errors)
        {
            var resultMessages = errors.Select(error => new ResultMessage
            {
                Content = error,
                Type = ResultMessageType.Error
            }).ToList();

            return new OperationResult(ResultStatus.Error, resultMessages);
        }
        public static OperationResult NotFound()
        {
            return new OperationResult(ResultStatus.NotFound);
        }
        public static OperationResult Unauthorized()
        {
            return new OperationResult(ResultStatus.Unauthorized);
        }
        public static OperationResult Invalid(List<ValidationError> validationErrors = null)
        {
            return new OperationResult(ResultStatus.Invalid, null, validationErrors);
        }

        #endregion
    }
}
