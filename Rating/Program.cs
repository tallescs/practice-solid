using Rating.Infrastructure;

namespace Rating
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new ConsoleLogger();
            logger.Log("Insurance Rating System Starting...");

            var engine = new RatingEngine(logger);
            engine.Rate();

            if (engine.Rating > 0)
            {
                logger.Log($"Rating: {engine.Rating}");
            }
            else
            {
                logger.Log("No rating produced.");
            }
        }
    }
}