using System.Collections.Generic;
using System.Linq;

namespace CodeBlocks.Core.Model
{
    public class Result : IResult
    {
        public bool Success { get; } = true;

        //public string ErrorMessage
        //{
        //    get
        //    {
        //        if (Messages == null || Messages.Count == 0)
        //            return null;

        //        return Messages.FirstOrDefault(m => m.Type == ResultMessageType.Error)?.Content;
        //    }
        //}

        //public string SuccessMessage
        //{
        //    get
        //    {
        //        if (Messages == null || Messages.Count == 0)
        //            return null;

        //        return Messages.FirstOrDefault(m => m.Type == ResultMessageType.Success)?.Content;
        //    }
        //}



        public List<ResultMessage> Messages { get; } = new List<ResultMessage>();

        public List<ResultMessage> ValidationErrorsMessages
        {
            get
            {
                return Messages?.Where(m => m.Type == ResultMessageType.ValidationError).ToList();
            }
        }

        public List<ResultMessage> SuccessMessages
        {
            get
            {
                return Messages?.Where(m => m.Type == ResultMessageType.Success).ToList();
            }
        }

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

        public Result(bool success, List<ResultMessage> resultMessages = null)
        {
            Success = success;
            if (resultMessages != null)
            {
                Messages.AddRange(resultMessages);
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

        public Result(bool success, T value, List<ResultMessage> resultMessages = null) : base(success, resultMessages)
        {
            Value = value;
        }

        public T Value { get; }
    }
}
