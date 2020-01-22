namespace CodeBlocks.Web.Operations
{
    public enum ResultStatus
    {
        // Success Operation
        Ok = 1,

        //Error Operation
        Error = 10,

        // Validation Errors
        Invalid = 20,

        // Unauthorized Operation
        Unauthorized = 30,

        // Operation Not Found
        NotFound = 40
    }
}
