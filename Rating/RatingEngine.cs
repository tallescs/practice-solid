using Rating.Rater;

namespace Rating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        public ConsoleLogger Logger { get; set; } = new ConsoleLogger();
        private readonly FilePolicySource _policySource = new FilePolicySource();
        private readonly JsonPolicySerializer _policySeralizer = new JsonPolicySerializer();

        public decimal Rating { get; set; }
        public void Rate()
        {
            Logger.Log("Starting rate.");
            Logger.Log("Loading policy.");

            string policyJson = _policySource.GetPolicyFromSource();
            var policy = _policySeralizer.GetPolicyFromJson(policyJson);

            var factory = new RaterFactory();

            var rater = factory.Create(policy, Logger);
            Rating = rater.Rate(policy);

            Logger.Log("Rating completed.");
        }
    }
}