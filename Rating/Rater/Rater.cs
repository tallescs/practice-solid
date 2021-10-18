namespace Rating.Rater
{
    public abstract class Rater
    {
        protected readonly ConsoleLogger _logger;

        public Rater(ConsoleLogger logger)
        {
            _logger = logger;
        }

        public abstract decimal Rate(Policy policy);
    }
}
