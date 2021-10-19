using Rating.Infrastructure;
using Rating.Rater;

namespace Rating
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new ConsoleLogger();
            logger.Log("Insurance Rating System Starting...");


            var engine = new RatingEngine(logger,
                new FilePolicySource(),
                new JsonPolicySerializer(),
                new RaterFactory(logger));
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