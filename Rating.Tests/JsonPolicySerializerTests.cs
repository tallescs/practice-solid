using NUnit.Framework;
using Rating.Infrastructure;

namespace Rating.Tests
{
    public class JsonPolicySerializerTests
    {
        [Test]
        public void WhenEmptyJson_ReturnsDefaultPolicy()
        {
            var jsonString = "{}";
            var serializer = new JsonPolicySerializer();
            var emptyPolicy = new Policy();

            var result = serializer.GetPolicyFromString(jsonString);

            AssertPoliciesAreEqual(emptyPolicy, result);
        }

        [Test]
        public void ReturnsSimpleLandPolicy_FromValidJson()
        {
            var json = @"{""type"": ""Land"", ""bondAmount"": 1000}";
            var serializer = new JsonPolicySerializer();
            var policy = new Policy { Type = PolicyType.Land, BondAmount = 1000 };

            var result = serializer.GetPolicyFromString(json);

            AssertPoliciesAreEqual(policy, result);
        }

        public void AssertPoliciesAreEqual(Policy p1, Policy p2)
        {
            Assert.AreEqual(p1.Address, p2.Address);
            Assert.AreEqual(p1.Amount, p2.Amount);
            Assert.AreEqual(p1.BondAmount, p2.BondAmount);
            Assert.AreEqual(p1.DateOfBirth, p2.DateOfBirth);
            Assert.AreEqual(p1.Deductible, p2.Deductible);
            Assert.AreEqual(p1.FullName, p2.FullName);
            Assert.AreEqual(p1.IsSmoker, p2.IsSmoker);
            Assert.AreEqual(p1.Make, p2.Make);
            Assert.AreEqual(p1.Miles, p2.Miles);
            Assert.AreEqual(p1.Model, p2.Model);
            Assert.AreEqual(p1.Size, p2.Size);
            Assert.AreEqual(p1.Type, p2.Type);
            Assert.AreEqual(p1.Valuation, p2.Valuation);
            Assert.AreEqual(p1.Year, p2.Year);
        }
    }
}