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
}
