using Rating.Infrastructure;

namespace Rating.Rater
{
    public class UnknownPolicyRater : Rater
    {
        public UnknownPolicyRater(ILogger logger)
            : base(logger)
        {
        }

        public override decimal Rate(Policy policy)
        {
            _logger.Log("Unknown policy type");
            return 0;
        }
    }
}