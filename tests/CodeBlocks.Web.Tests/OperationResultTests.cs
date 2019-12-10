using CodeBlocks.Core.Model;
using CodeBlocks.Core.Web.Operations;
using System.Collections.Generic;
using Xunit;

namespace CodeBlocks.Web.Tests
{
    public class OperationResultTests
    {

        [Fact]
        public void OperationResult_Ctor_Success()
        {
            // Created with static method
            var result1 = OperationResult<int>.Ok(1);
            Assert.True(result1.Success);
            Assert.Equal(ResultStatus.Ok, result1.Status);
            Assert.Equal(1, result1.Value);

            // Created with ctor
            var result3 = new OperationResult<int>();
            Assert.True(result3.Success);
            Assert.Equal(ResultStatus.Ok, result3.Status);
            // ...with data
            var result4 = new OperationResult<int>(ResultStatus.Ok, 1);
            Assert.True(result4.Success);
            Assert.Equal(ResultStatus.Ok, result4.Status);
            Assert.Equal(1, result4.Value);
        }


        [Fact]
        public void OperationResult_Ctor_Invalid()
        {
            var errorCount = 10;
            var validationErrors = new List<ValidationError>();
            for (int i = 0; i < errorCount; i++)
            {
                validationErrors.Add(new ValidationError { Code = $"{i}", Error = $"val error {i}" });
            }


            // Created with static method
            var result1 = OperationResult<int>.Invalid(validationErrors);
            Assert.False(result1.Success);
            Assert.Equal(ResultStatus.Invalid, result1.Status);
            Assert.NotNull(result1.ValidationErrors);
            Assert.Equal(errorCount, result1.ValidationErrors.Count);

            // Created with ctor
            var result3 = new OperationResult<int>(ResultStatus.Invalid);
            Assert.False(result3.Success);
            Assert.Equal(ResultStatus.Invalid, result3.Status);
            // ...with data
            var result4 = new OperationResult<int>(ResultStatus.Invalid, 1);
            Assert.False(result4.Success);
            Assert.Equal(ResultStatus.Invalid, result4.Status);
            Assert.Equal(1, result4.Value);
        }


        [Fact]
        public void OperationResult_Ctor_Error()
        {
            // Created with static method
            var result1 = OperationResult<int>.Error();
            Assert.False(result1.Success);
            Assert.Equal(ResultStatus.Error, result1.Status);

            // Created with ctor
            var result2 = new OperationResult<int>(ResultStatus.Error);
            Assert.False(result2.Success);
            Assert.Equal(ResultStatus.Error, result2.Status);
        }


        [Fact]
        public void OperationResult_Ctor_NotFound()
        {
            // Created with static method
            var result1 = OperationResult<int>.NotFound();
            Assert.False(result1.Success);
            Assert.Equal(ResultStatus.NotFound, result1.Status);

            // Created with ctor
            var result2 = new OperationResult<int>(ResultStatus.NotFound);
            Assert.False(result2.Success);
            Assert.Equal(ResultStatus.NotFound, result2.Status);
        }

        [Fact]
        public void OperationResult_Ctor_Unauthorized()
        {
            // Created with static method
            var result1 = OperationResult<int>.Unauthorized();
            Assert.False(result1.Success);
            Assert.Equal(ResultStatus.Unauthorized, result1.Status);

            // Created with ctor
            var result2 = new OperationResult<int>(ResultStatus.Unauthorized);
            Assert.False(result2.Success);
            Assert.Equal(ResultStatus.Unauthorized, result2.Status);
        }
    }
}
