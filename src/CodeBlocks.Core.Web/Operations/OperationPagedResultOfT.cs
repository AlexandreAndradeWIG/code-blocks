using CodeBlocks.Core.Model;
using System.Collections.Generic;
using System.Linq;

namespace CodeBlocks.Web.Operations
{
    public class OperationPagedResult<T> : PagedResult<T>, IOperationResult where T : class
    {
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        [System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
        public ResultStatus Status { get; set; } = ResultStatus.Ok;



        public OperationPagedResult() : base()
        {
        }
        public OperationPagedResult(IList<T> value) : base(value)
        {
        }
        public OperationPagedResult(PagedResult<T> pagedResult) : base(pagedResult.Data)
        {
            Page = pagedResult.Page;
            PageCount = pagedResult.PageCount;
            PageSize = pagedResult.PageSize;
            RowCount = pagedResult.RowCount;
        }
        public OperationPagedResult(ResultStatus status, IList<T> value = default, List<ResultMessage> resultMessages = null, List<ValidationError> validationErrors = null) : base(status == ResultStatus.Ok, value, resultMessages, validationErrors)
        {
            Status = status;
        }

        public static OperationPagedResult<T> Ok(IList<T> value)
        {
            return new OperationPagedResult<T>(value);
        }
        public static OperationPagedResult<T> Error(List<ResultMessage> errors = null)
        {
            return new OperationPagedResult<T>(ResultStatus.Error, default, errors);
        }
        public static OperationPagedResult<T> Error(params string[] errors)
        {
            var resultMessages = errors.Select(error => new ResultMessage
            {
                Content = error,
                Type = ResultMessageType.Error
            }).ToList();

            return new OperationPagedResult<T>(ResultStatus.Error, default, resultMessages);
        }
        public static OperationPagedResult<T> NotFound()
        {
            return new OperationPagedResult<T>(ResultStatus.NotFound);
        }
        public static OperationPagedResult<T> Unauthorized()
        {
            return new OperationPagedResult<T>(ResultStatus.Unauthorized);
        }
        public static OperationPagedResult<T> Invalid(List<ValidationError> validationErrors = null)
        {
            return new OperationPagedResult<T>(ResultStatus.Invalid, default, null, validationErrors);
        }

    }
}
