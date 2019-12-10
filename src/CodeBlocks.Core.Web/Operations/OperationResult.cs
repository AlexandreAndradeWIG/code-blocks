using CodeBlocks.Core.Model;
using System.Collections.Generic;

namespace CodeBlocks.Core.Web.Operations
{
    public class OperationResult : Result
    {
        public ResultStatus Status { get; } = ResultStatus.Ok;


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
        public ResultStatus Status { get; } = ResultStatus.Ok;



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



    public enum ResultStatus
    {
        Ok,
        Error,
        Invalid,
        Unauthorized,
        NotFound
    }
}
