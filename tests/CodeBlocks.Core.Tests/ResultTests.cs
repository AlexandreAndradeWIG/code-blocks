using System.Collections.Generic;
using System.Linq;
using CodeBlocks.Core.Model;
using Xunit;

namespace CodeBlocks.Core.Tests
{
    public class ResultTests
    {
        [Fact]
        public void Result_Empty_Ctor_Success()
        {
            IResult result = new Result();
            Assert.False(result.Success);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void Result_Ctor_Success(bool success)
        {
            IResult result = new Result(success);
            Assert.Equal(success, result.Success);
        }


        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void Result_Has_Error_Messages(int errorCount)
        {
            var result = new Result();
            result.Messages = GetErrorMessages(errorCount).ToList();

            Assert.NotNull(result.ErrorMessage);
            Assert.Equal(GetErrorMessageContent(1), result.ErrorMessage);
        }


        public static IEnumerable<ResultMessage> GetErrorMessages(int messageCount)
        {
            var messages = new List<ResultMessage>
            {
                new ResultMessage { Content = GetErrorMessageContent(1), Type = ResultMessageType.Error },
                new ResultMessage { Content = GetErrorMessageContent(2), Type = ResultMessageType.Error },
                new ResultMessage { Content = GetErrorMessageContent(3), Type = ResultMessageType.Error },
                new ResultMessage { Content = GetErrorMessageContent(4), Type = ResultMessageType.Error }
            };

            return messages.Take(messageCount);
        }

        public static string GetErrorMessageContent(int errorNumber)
        {
            return $"err_{errorNumber}";
        }
    }
}
