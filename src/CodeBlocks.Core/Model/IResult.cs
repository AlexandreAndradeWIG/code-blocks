using System.Collections.Generic;

namespace CodeBlocks.Core.Model
{
    public interface IResult
    {
        bool Success { get; }


        //string ErrorMessage { get; }
        //string SuccessMessage { get; }
    }


    public interface IResult<T> : IResult
    {
        public T Value { get; }
    }

    public interface IPagedResult<T> : IResult
    {
        public IList<T> Value { get; }
    }
}
