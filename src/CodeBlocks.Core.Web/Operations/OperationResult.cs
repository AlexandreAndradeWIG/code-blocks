using CodeBlocks.Core.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace CodeBlocks.Core.Web.Operations
{

    public class OperationResult : Result
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public ResultStatus Status { get; set; } = ResultStatus.Ok;


        public OperationResult() : base()
        {

        }
        public OperationResult(ResultStatus status, List<ResultMessage> resultMessages = null, List<ValidationError> validationErrors = null) : base(status == ResultStatus.Ok, resultMessages, validationErrors)
        {
            Status = status;
        }
    }
    public class OperationResult<T> : Result<T>
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public ResultStatus Status { get; set; } = ResultStatus.Ok;

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


        public static OperationResult<T> Ok(T value)
        {
            return new OperationResult<T>(value);
        }
        public static OperationResult<T> Error(List<ResultMessage> errors = null)
        {
            return new OperationResult<T>(ResultStatus.Error, default, errors);
        }
        public static OperationResult<T> NotFound()
        {
            return new OperationResult<T>(ResultStatus.NotFound);
        }
        public static OperationResult<T> Unauthorized()
        {
            return new OperationResult<T>(ResultStatus.Unauthorized);
        }
        public static OperationResult<T> Invalid(List<ValidationError> validationErrors = null)
        {
            return new OperationResult<T>(ResultStatus.Invalid, default, null, validationErrors);
        }
    }


    public class OperationPagedResult<T> : PagedResult<T> where T : class
    {
        [JsonConverter(typeof(StringEnumConverter))]
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


    public enum ResultStatus
    {
        Ok,
        Error,
        Invalid,
        Unauthorized,
        NotFound
    }
}
