using System.Collections.Generic;
using System.Linq;

namespace WIG.Core.Model
{
    public class Result : IResult
    {
        public bool Success { get; private set; }

        public string ErrorMessage
        {
            get
            {
                if (Messages == null || Messages.Count == 0)
                    return null;

                return Messages.FirstOrDefault(m => m.Type == ResultMessageType.Error)?.Content;
            }
        }

        public string SuccessMessage
        {
            get
            {
                if (Messages == null || Messages.Count == 0)
                    return null;

                return Messages.FirstOrDefault(m => m.Type == ResultMessageType.Success)?.Content;
            }
        }

        public List<ResultMessage> Messages { get; set; }


        public Result()
        {

        }

        public Result(bool success)
        {
            Success = success;
        }
    }
}
