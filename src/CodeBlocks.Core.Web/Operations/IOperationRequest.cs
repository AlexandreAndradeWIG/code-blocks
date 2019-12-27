namespace CodeBlocks.Core.Web.Operations
{
    public interface IOperationRequest
    {

    }

    public interface IPagingOperationRequest
    {
        int? Page { get; }
        int? PageSize { get; }
    }
}
