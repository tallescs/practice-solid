using Rating.Infrastructure;

namespace Rating.Tests
{
    public class FakePolicySource : IPolicySource
    {
        public string PolicyString { get; set; } = "";
        public string GetPolicyFromSource() => PolicyString;
    }
}