namespace CodeBlocks.Core.Model
{
    public interface IResult
    {
        bool Success { get; }


        string ErrorMessage { get; }
        string SuccessMessage { get; }
    }
}
