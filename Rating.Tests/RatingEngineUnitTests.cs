using Newtonsoft.Json;
using NUnit.Framework;
using System.IO;

namespace Rating.Tests
{
    public class RatingEngineUnitTests
    {
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
            File.WriteAllText("policy.json", jsonText);

            var ratingEngine = new RatingEngine();
            ratingEngine.Rate();

            Assert.AreEqual(100, ratingEngine.Rating);
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
            File.WriteAllText("policy.json", jsonText);

            var ratingEngine = new RatingEngine();
            ratingEngine.Rate();

            Assert.AreEqual(0, ratingEngine.Rating);
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
            File.WriteAllText("policy.json", jsonText);

            var ratingEngine = new RatingEngine();
            ratingEngine.Rate();

            Assert.AreEqual(900, ratingEngine.Rating);
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
            File.WriteAllText("policy.json", jsonText);

            var ratingEngine = new RatingEngine();
            ratingEngine.Rate();

            Assert.AreEqual(1000, ratingEngine.Rating);
        }
    }
}
