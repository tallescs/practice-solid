using Rating.Infrastructure;
using System.Collections.Generic;
namespace Rating.Tests
{
    public class FakeLogger : ILogger
    {
        public IList<string> LogMessages { get; set; } = new List<string>();
        public void Log(string message) => LogMessages.Add(message);

    }
}