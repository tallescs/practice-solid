using Newtonsoft.Json;
using NUnit.Framework;
using Rating.Infrastructure;
using Rating.Rater;

namespace Rating.Tests
{
    public class RatingEngineUnitTests
    {
        private FakeLogger _logger;
        private FakePolicySource _policySource;
        private JsonPolicySerializer _policySerializer;
        private RatingEngine _ratingEngine;

        public RatingEngineUnitTests()
        {
            _logger = new FakeLogger();
            _policySource = new FakePolicySource();
            _policySerializer = new JsonPolicySerializer();

            _ratingEngine = new RatingEngine(_logger, 
                _policySource, 
                _policySerializer,
                new RaterFactory(_logger));
        }

        [Test]
        public void WhenLand_BoundAndValuation2000_ExpectRating100()
        {
            var policy = new Policy
            {
                Type = PolicyType.Land,
                BondAmount = 2000,
                Valuation = 2000
            };

            var jsonText = JsonConvert.SerializeObject(policy);
            _policySource.PolicyString = jsonText;

            _ratingEngine.Rate();

            Assert.AreEqual(100, _ratingEngine.Rating);
        }

        [Test]
        public void WhenLand_Bound1500Valuation2000_ExpectRating0()
        {
            var policy = new Policy
            {
                Type = PolicyType.Land,
                BondAmount = 1500,
                Valuation = 2000
            };

            var jsonText = JsonConvert.SerializeObject(policy);
            _policySource.PolicyString = jsonText;

            _ratingEngine.Rate();

            Assert.AreEqual(0, _ratingEngine.Rating);
        }

        [Test]
        public void WhenAuto_BMWDeductibleGreater500_ExpectRating900()
        {
            var policy = new Policy
            {
                Type = PolicyType.Auto,
                Deductible = 501,
                Make = "BMW"
            };
            var jsonText = JsonConvert.SerializeObject(policy);
            _policySource.PolicyString = jsonText;

            _ratingEngine.Rate();

            Assert.AreEqual(900, _ratingEngine.Rating);
        }
    
        [Test]
        public void WhenFlood_ElevationAboveSeaLower100BoundAmount10000_ExpectRating1000()
        {
            var policy = new Policy
            {
                BondAmount = 10000,
                Valuation = 12000,
                Type = PolicyType.Flood,
                ElevationAboveSeaLevelFeet = 99
            };

            var jsonText = JsonConvert.SerializeObject(policy);
            _policySource.PolicyString = jsonText;

            _ratingEngine.Rate();

            Assert.AreEqual(1000, _ratingEngine.Rating);
        }
    }
}
