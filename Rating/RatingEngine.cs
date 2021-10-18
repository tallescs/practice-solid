using Rating.Infrastructure;
using Rating.Rater;

namespace Rating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        private readonly ILogger _logger;
        private readonly FilePolicySource _policySource = new FilePolicySource();
        private readonly JsonPolicySerializer _policySeralizer = new JsonPolicySerializer();

        public RatingEngine(ILogger logger)
        {
            _logger = logger;
        }

        public decimal Rating { get; set; }
        public void Rate()
        {
            _logger.Log("Starting rate.");
            _logger.Log("Loading policy.");

            string policyJson = _policySource.GetPolicyFromSource();
            var policy = _policySeralizer.GetPolicyFromJson(policyJson);

            var factory = new RaterFactory();

            var rater = factory.Create(policy, _logger);
            Rating = rater.Rate(policy);

            _logger.Log("Rating completed.");
        }
    }
}