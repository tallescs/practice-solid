using System;

namespace Rating.Infrastructure
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message) =>
            Console.WriteLine(message);
    }
}