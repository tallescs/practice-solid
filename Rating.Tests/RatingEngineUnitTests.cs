using Newtonsoft.Json;
using NUnit.Framework;
using System.IO;

namespace Rating.Tests
{
    public class RatingEngineUnitTests
    {
        [Test]
        public void WhenLandBoundAndValuation2000_ExpectRating100()
        {
            var policy = new Policy
            {
                Type = PolicyType.Land,
                BondAmount = 2000,
                Valuation = 2000
            };
            var jsonText = JsonConvert.SerializeObject(policy);
            File.WriteAllText("policy.json", jsonText);

            var ratingEngine = new RatingEngine();
            ratingEngine.Rate();

            Assert.AreEqual(100, ratingEngine.Rating);
        }

        [Test]
        public void WhenLandBound1500Valuation2000_ExpectRating0()
        {
            var policy = new Policy
            {
                Type = PolicyType.Land,
                BondAmount = 1500,
                Valuation = 2000
            };

            var jsonText = JsonConvert.SerializeObject(policy);
            File.WriteAllText("policy.json", jsonText);

            var ratingEngine = new RatingEngine();
            ratingEngine.Rate();

            Assert.AreEqual(0, ratingEngine.Rating);
        }

        [Test]
        public void WhenAutoBMWDeductibleGreater500_ExpectRating900()
        {
            var policy = new Policy
            {
                Type = PolicyType.Auto,
                Deductible = 501,
                Make = "BMW"
            };
            var jsonText = JsonConvert.SerializeObject(policy);
            File.WriteAllText("policy.json", jsonText);

            var ratingEngine = new RatingEngine();
            ratingEngine.Rate();

            Assert.AreEqual(900, ratingEngine.Rating);
        }
    }
}
