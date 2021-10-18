using System;

namespace Rating.Rater
{
    public class AutoPolicyRater : Rater
    {
        public AutoPolicyRater(ConsoleLogger logger)
            : base(logger)
        {
        }

        public override decimal Rate(Policy policy)
        {
            _logger.Log("Rating AUTO policy...");
            _logger.Log("Validating policy.");
            if (String.IsNullOrEmpty(policy.Make))
            {
                _logger.Log("Auto policy must specify Make");
                return 0m;
            }
            if (policy.Make == "BMW")
            {
                if (policy.Deductible < 500)
                {
                    return 1000m;
                }
                return 900m;
            }
            return 0m;
        }
    }
}
