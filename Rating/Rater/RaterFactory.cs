namespace Rating.Rater
{
    public class RaterFactory
    {
        public Rater Create(Policy policy, ConsoleLogger logger)
        {
            switch(policy.Type)
            {
                case PolicyType.Auto:
                    return new AutoPolicyRater(logger);
                case PolicyType.Land:
                    return new LandPolicyRater(logger);
                case PolicyType.Life:
                    return new LifePolicyRater(logger);
                case PolicyType.Flood:
                    return new FloodPolicyRater(logger);
                default:
                    return new UnknownPolicyRater(logger); ;
            }
        }
    }
}