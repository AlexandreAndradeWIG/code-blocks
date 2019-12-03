using CodeBlocks.Core.Model;
using System.Collections.Generic;

namespace CodeBlocks.Core.Web.Operations
{
    public class OperationResult<T> : Result<T>
    {
        public ResultStatus Status { get; } = ResultStatus.Ok;



        public OperationResult() : base()
        {

        }

        public OperationResult(T value) : base(value)
        {

        }

        public OperationResult(ResultStatus status, List<ResultMessage> resultMessages = null) : base(status == ResultStatus.Ok, resultMessages)
        {
            Status = status;
        }


        public OperationResult(ResultStatus status, T value) : base(status == ResultStatus.Ok, value)
        {
            Status = status;
        }


        public static OperationResult<T> Ok(T value)
        {
            return new OperationResult<T>(value);
        }


        public static OperationResult<T> Error(List<ResultMessage> errors = null)
        {
            return new OperationResult<T>(ResultStatus.Error, errors);
        }

        public static OperationResult<T> NotFound()
        {
            return new OperationResult<T>(ResultStatus.NotFound);
        }

        public static OperationResult<T> Unauthorized()
        {
            return new OperationResult<T>(ResultStatus.Unauthorized);
        }

        public static OperationResult<T> Invalid(List<ResultMessage> validationErrors = null)
        {
            return new OperationResult<T>(ResultStatus.Invalid, validationErrors);
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
