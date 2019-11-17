using System;

namespace Blocks.Core.Abstractions
{
    /// <summary>
    /// Abstraction for a DateTime providing service.
    /// This is useful to make the code testable, and make it possible to test code that depends on DateTime.Now in the past or future.
    /// </summary>
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
        DateTime UtcNow { get; }
    }
}
